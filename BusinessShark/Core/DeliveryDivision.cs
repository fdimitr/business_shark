using System.Drawing;
using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal abstract class DeliveryDivision(int divisionId, Point location) : Division(divisionId, location)
    {
        public Dictionary<Enums.ItemType, Item.Item> WarehouseInput = new();  //to
        public Dictionary<Enums.ItemType, Item.Item> WarehouseOutput = new(); //from

        public List<Routes> Routes { get; set; } = new();

        public void StartTransferItems()
        {
            foreach (var route in Routes)
            {
                if(route.FromDivision.WarehouseOutput.TryGetValue(route.TransferringItemType, out var item))
                {
                    if(item ==  null || item.Quantity == 0)
                    {

                    }
                    else
                    {
                        route.ToDivision.WarehouseInput.TryGetValue(route.TransferringItemType, out var checkItem);
                        {
                            if (checkItem == null)
                            {
                                route.ToDivision.WarehouseInput.Add(route.TransferringItemType, item);
                                route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity = 0;
                                route.ToDivision.WarehouseInput[route.TransferringItemType].Quantity = 0;
                            }
                        }
                        if (item.Quantity >= route.TransferringCount)
                        {
                            route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuality = (route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuality * route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity + route.FromDivision.WarehouseOutput[route.TransferringItemType].Quality * route.TransferringCount) / (route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity + route.TransferringCount); 
                            route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity += route.TransferringCount;
                            route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity -= route.TransferringCount;
                        }
                        else
                        {
                            route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuality = (route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuality * route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity + route.FromDivision.WarehouseOutput[route.TransferringItemType].Quality * route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity) / (route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity + route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity);
                            route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity += route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity;

                            route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity = 0;
                        }
                    }
                }
                
            }
        }
    }
}
