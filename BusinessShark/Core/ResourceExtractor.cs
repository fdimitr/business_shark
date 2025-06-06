using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;
using MessagePack;
using System.Drawing;


namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class ResourceExtractor(
        int divisionId,
        string name,
        ItemDefinition resourceDefinition,
        float techLevel,
        Tools toolPark,
        Workers workers,
        Location location) : DeliveryDivision(divisionId, name, location)

    {
        public ItemDefinition ResourceDefinition = resourceDefinition;
        public float ProgressProduction; //procent of single product left on production
        public float ProgressQuality;
        public float ResourceDepositQuality = 5; // replace with the quality of this type of resource at the deposit
        public float TechLevel = techLevel;
        public Tools ToolPark = toolPark;
        public Workers FactoryWorkers = workers;
        public Enums.ItemType ExtractingItemType { get; set; } = resourceDefinition.ItemDefinitionId;

        public override void StartCalculation()
        {
            ProgressQuality = CalculateResourceQuality();
            ProgressProduction = CalculateResourceQuantity(ResourceDefinition.BaseProductionCount);

            if (ProgressProduction >= 1)
            {
                var productionCount = (int)Math.Round(ProgressProduction);

                if (WarehouseInput.TryGetValue(ResourceDefinition.ItemDefinitionId, out Item.Item? storedItem))
                {
                    storedItem.ProcessingQuality = ProgressQuality;
                    WarehouseInput[ResourceDefinition.ItemDefinitionId].ProcessingQuantity = productionCount;
                }
                else
                {
                    WarehouseInput[ResourceDefinition.ItemDefinitionId] =
                        new Item.Item(ResourceDefinition, 0, 0, productionCount, ProgressQuality);
                }

                ProgressProduction -= productionCount;
                ProgressQuality = 0;
            }
        }

        public override void CompleteCalculation()
        {
            if(WarehouseOutput.TryGetValue(ExtractingItemType, out var item))
            {
                if(item.Quantity >= 0)
                {
                    item.ProcessingQuality = WarehouseInput[ExtractingItemType].ProcessingQuality;
                    item.ProcessingQuantity = WarehouseInput[ExtractingItemType].ProcessingQuantity;
                    if (item.ProcessingQuantity == 0)
                    {
                        return; // No items to process
                    }
                    var newQuality = CalculateWarehouseQuality(item);

                    item.Quantity += item.ProcessingQuantity;
                    item.Quality = newQuality;

                    item.ResetProcessing();
                    WarehouseInput[ExtractingItemType].Quality = 0;
                    WarehouseInput[ExtractingItemType].Quantity = 0;
                }
            }
            else
            {
                WarehouseOutput.Add(ExtractingItemType, 
                    new Item.Item(ResourceDefinition, 0, 0, 0, 0, 0));
            }
        }

        internal float CalculateResourceQuality()
        {
            float TotalQuality = ResourceDepositQuality * (TechLevel * ResourceDefinition.TechImpactQuality
                            + ToolPark.TechLevel * ResourceDefinition.ToolImpactQuality
                            + FactoryWorkers.TechLevel * ResourceDefinition.WorkerImpactQuality);
            return TotalQuality;
        }

        internal float CalculateResourceQuantity(float baseProductionCount)
        {
            float TotatlQuantity = baseProductionCount * (TechLevel * ResourceDefinition.TechImpactQuantity
                            + ToolPark.TechLevel * ResourceDefinition.ToolImpactQuantity
                            + FactoryWorkers.TechLevel * ResourceDefinition.WorkerImpactQuantity);
            return TotatlQuantity;
        }
    }
}
