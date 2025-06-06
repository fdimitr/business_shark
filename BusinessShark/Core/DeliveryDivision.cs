using System.Drawing;
using System.Text.Json.Serialization;
using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;
using MessagePack;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    [MessagePack.Union(1, typeof(Warehouse))]
    [MessagePack.Union(2, typeof(Factory))]
    internal abstract class DeliveryDivision(int divisionId, string name, Location location) : Division(divisionId, name, location)
    {
        public Dictionary<Enums.ItemType, Item.Item> WarehouseInput = new();  //to
        public Dictionary<Enums.ItemType, Item.Item> WarehouseOutput = new(); //from

        public List<Routes> Routes { get; set; } = new();

        public void StartTransferItems(Market market)
        {
            foreach (var route in Routes)
            {
                DeliveryDivision fromDivision = market.GetDeliveryDivisionById(route.FromDivisionId);
                if (fromDivision.WarehouseOutput.TryGetValue(route.TransferringItemType, out var item))
                {
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
                    if(item is { Quantity: > 0 })
                    {
                        
                        if (this.WarehouseInput.TryAdd(route.TransferringItemType, (Item.Item)item.Clone()))
                        {
                            this.WarehouseInput[route.TransferringItemType].ProcessingQuantity = 0;
                            this.WarehouseInput[route.TransferringItemType].Quantity = 0;
                        }
                        var sourceItem = fromDivision.WarehouseOutput[route.TransferringItemType];
                        var targetItem = this.WarehouseInput[route.TransferringItemType];

                        

                        if (item.Quantity >= route.TransferringCount)
                        {
                            targetItem.ProcessingQuality =
                                CalculateWarehouseQuality(targetItem.ProcessingQuantity, targetItem.ProcessingQuality, route.TransferringCount, sourceItem.Quality);

                            targetItem.ProcessingQuantity += route.TransferringCount;
                            sourceItem.Quantity -= route.TransferringCount;
                        }
                        else
                        {
                            targetItem.ProcessingQuality =
                                CalculateWarehouseQuality(targetItem.ProcessingQuantity, targetItem.ProcessingQuality, sourceItem.Quantity, sourceItem.Quality);
                            targetItem.ProcessingQuantity += sourceItem.Quantity;

                            sourceItem.Quantity = 0;
                            sourceItem.Quality = 0;
                        }
                    }
                }
                
            }
        }

        public void CompleteTransferItems()
        {
            foreach (var route in Routes)
            {
                if (this.WarehouseInput.TryGetValue(route.TransferringItemType, out var item))
                {
                    if (item.ProcessingQuantity > 0)
                    {
                        var newQuality = CalculateWarehouseQuality(item);

                        item.Quantity += item.ProcessingQuantity;
                        item.Quality = newQuality;

                        item.ResetProcessing();
                    }
                }
            }
        }

        internal static float CalculateWarehouseQuality(float existingQuantity, float existingQuality, float addedQuantity, float addedQuality)
        {
            float totalWeight = existingQuantity + addedQuantity;
            if (totalWeight == 0)
                throw new InvalidOperationException("Суммарное количество не может быть нулевым.");

            float weightedSum = existingQuality * existingQuantity + addedQuality * addedQuantity;
            return weightedSum / totalWeight;
        }

        internal static float CalculateWarehouseQuality(Item.Item item)
        {
            return CalculateWarehouseQuality(item.Quantity, item.Quality, item.ProcessingQuantity, item.ProcessingQuality);
        }
    }
}
