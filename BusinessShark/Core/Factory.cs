using System.Drawing;
using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Factory(
        int divisionId,
        ItemDefinition productDefinition,
        float techLevel,
        Tools toolPark,
        Workers workers,
        Point location) : DeliveryDivision(divisionId, location)
    {
        internal struct QualityItem(float quality, float qualityImpact)
        {
            public float Quality = quality;
            public float QualityImpact = qualityImpact;
        }

        public ItemDefinition ProductDefinition = productDefinition;
        public float ProgressProduction; //procent of single product left on production
        public float ProgressQuality;
        public float TechLevel = techLevel;
        public Tools ToolPark = toolPark;
        public Workers FactoryWorkers = workers;
        private bool isProductionCompleted = true;

        public override void StartCalculation()
        {
            float cycleProgressQuality = 0;

            if (isProductionCompleted)
            {
                isProductionCompleted = false;

                // Start production
                if (PossibleToProduce())
                {
                    // Take resources for production
                    var listForQualityCalc = new List<QualityItem>();
                    foreach (var unit in ProductDefinition.ProductionUnits)
                    {
                        var item = WarehouseInput[unit.ComponentDefinitionId];
                        item.Quantity -= unit.ProductionQuantity;
                        listForQualityCalc.Add(new QualityItem(item.Quality, unit.QualityImpact));
                    }

                    // Calculate production quality
                    cycleProgressQuality = CalculateProductionQuality(listForQualityCalc);
                }
                else
                {
                    return;
                }
            }

            var cycleProgressQuantity = CalculateProductionQuantity(ProductDefinition.BaseProductionCount);

            ProgressQuality += CalculateWarehouseQuality(ProgressProduction, ProgressQuality, cycleProgressQuantity, cycleProgressQuality);
            ProgressProduction += cycleProgressQuantity;
            

            // Completion of production
            if (ProgressProduction >= 1)
            {
                var productionCount = (int)Math.Truncate(ProgressProduction);
                ProgressProduction -= productionCount;

                if (WarehouseOutput.TryGetValue(ProductDefinition.ItemDefinitionId, out Item.Item? storedItem))
                {
                    storedItem.ProcessingQuality = ProgressQuality;
                    WarehouseOutput[ProductDefinition.ItemDefinitionId].ProcessingQuantity += productionCount;
                }
                else
                {
                    WarehouseOutput[ProductDefinition.ItemDefinitionId] =
                        new Item.Item(ProductDefinition, 
                            processingQuantity: productionCount, 
                            processingQuality: ProgressQuality);
                }

                isProductionCompleted = true;
                // Reset progress
                if (ProgressProduction == 0) ProgressQuality = 0;
            }
        }

        public override void CompleteCalculation()
        {
            if (WarehouseOutput.TryGetValue(ProductDefinition.ItemDefinitionId, out var item))
            {
                var newQuality = CalculateWarehouseQuality(item);

                item.Quantity += item.ProcessingQuantity;
                item.Quality = newQuality;

                // Reset processing values
                item.ProcessingQuantity = 0;
                item.ProcessingQuality = 0;
            }
        }

        private bool PossibleToProduce()
        {
            foreach (var unit in ProductDefinition.ProductionUnits)
            {
                WarehouseInput.TryGetValue(unit.ComponentDefinitionId, out Item.Item? item);
                if (item == null || item.Quantity < unit.ProductionQuantity)
                    return false;
            }

            return true;
        }

        internal float CalculateProductionQuality(List<QualityItem> qualityItems)
        {
            return qualityItems.Sum(e => e.Quality * e.QualityImpact)
                            + TechLevel * ProductDefinition.TechImpactQuality
                            + ToolPark.TechLevel * ProductDefinition.ToolImpactQuality
                            + FactoryWorkers.TechLevel * ProductDefinition.WorkerImpactQuality;
        }

        internal float CalculateProductionQuantity(float baseProductionCount)
        {
            var quantity = TechLevel * ProductDefinition.TechImpactQuantity
                            + ToolPark.TechLevel * ProductDefinition.ToolImpactQuantity
                            + FactoryWorkers.TechLevel * ProductDefinition.WorkerImpactQuantity;
            return baseProductionCount * quantity;
        }

        internal float CalculateWarehouseQuality(float existingQuantity, float existingQuality, float addedQuantity, float addedQuality)
        {
            float totalWeight = existingQuantity + addedQuantity;
            if (totalWeight == 0)
                throw new InvalidOperationException("Суммарное количество не может быть нулевым.");

            float weightedSum = existingQuality * existingQuantity + addedQuality * addedQuantity;
            return weightedSum / totalWeight;
        }

        internal float CalculateWarehouseQuality(Item.Item item)
        {
            return CalculateWarehouseQuality(item.Quantity, item.Quality, item.ProcessingQuantity,
                item.ProcessingQuality);
        }

    }
}
