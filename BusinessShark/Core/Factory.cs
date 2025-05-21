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
        public ItemDefinition ProductDefinition = productDefinition;
        public float ProgressProduction;
        public float ProgressQuality;
        public float TechLevel = techLevel;
        public Tools ToolPark = toolPark;
        public Workers FactoryWorkers = workers;

        public override void StartCalculation()
        {
            if (ProgressProduction == 0)
            {
                // Start production
                if (PossibleToProduce())
                {
                    // Take resources for production
                    var listForQualityCalc = new List<Item.Item>();
                    foreach (var unit in ProductDefinition.ProductionUnits)
                    {
                        var item = WarehouseInput[unit.ComponentDefinitionId];
                        item.Quantity -= unit.ProductionQuantity;
                        listForQualityCalc.Add(new Item.Item(item.Definition, unit.ProductionQuantity, item.Quality));
                    }

                    // Calculate production quality
                    ProgressQuality = CalculateProductionQuality(listForQualityCalc);
                }
                else
                {
                    return;
                }
            }

            ProgressProduction += CalculateProductionQuantity(ProductDefinition.BaseProductionCount);

            // Completion of production
            if (ProgressProduction >= 1)
            {
                var productionCount = (int)Math.Round(ProgressProduction);

                if (WarehouseOutput.TryGetValue(ProductDefinition.ItemDefinitionId, out Item.Item? storedItem))
                {
                    storedItem.ProcessingQuality = ProgressQuality;
                    WarehouseOutput[ProductDefinition.ItemDefinitionId].ProcessingQuantity += productionCount;
                }
                else
                {
                    WarehouseOutput[ProductDefinition.ItemDefinitionId] =
                        new Item.Item(ProductDefinition, productionCount, ProgressQuality);
                }

                // Reset progress
                ProgressProduction = 0;
                ProgressQuality = 0;
            }
        }

        public override void CompleteCalculation()
        {
            var item = WarehouseOutput[ProductDefinition.ItemDefinitionId];
            var newQuality = CalculateWarehouseQuality();

            item.Quantity += item.ProcessingQuantity;
            item.Quality = newQuality;

            // Reset processing values
            item.ProcessingQuantity = 0;
            item.ProcessingQuality = 0;
        }

        private bool PossibleToProduce()
        {
            foreach (var unit in ProductDefinition.ProductionUnits)
            {
                WarehouseOutput.TryGetValue(unit.ComponentDefinitionId, out Item.Item? item);
                if (item == null || item.Quantity < unit.ProductionQuantity)
                    return false;
            }

            return true;
        }

        internal float CalculateProductionQuality(List<Item.Item> items)
        {
            float totalImpact = ProductDefinition.ProductionUnits.Sum(e => e.QualityImpact) +
                                ProductDefinition.ToolImpactQuality + ProductDefinition.TechImpactQuality +
                                ProductDefinition.WorkerImpactQuality;

            if (totalImpact == 0)
                throw new InvalidOperationException("Суммарное влияние на качество не может быть равно нулю.");

            var numerator = items.Sum(e =>
                                e.Quality * ProductDefinition.ProductionUnits
                                    .First(p => p.ComponentDefinitionId == e.Definition.ItemDefinitionId).QualityImpact)
                            + TechLevel * ProductDefinition.TechImpactQuality
                            + ToolPark.TechLevel * ProductDefinition.ToolImpactQuality
                            + FactoryWorkers.TechLevel * ProductDefinition.WorkerImpactQuality;
            return numerator / totalImpact;
        }

        internal float CalculateProductionQuantity(float baseProductionCount)
        {
            float totalImpact = ProductDefinition.ToolImpactQuantity + ProductDefinition.TechImpactQuantity +
                                ProductDefinition.WorkerImpactQuantity;

            if (totalImpact == 0)
                throw new InvalidOperationException("Суммарное влияние на количество не может быть равно нулю.");

            var numerator = TechLevel * ProductDefinition.TechImpactQuantity
                            + ToolPark.TechLevel * ProductDefinition.ToolImpactQuantity
                            + FactoryWorkers.TechLevel * ProductDefinition.WorkerImpactQuantity;
            var percent = numerator / totalImpact;
            return (float)Math.Round(baseProductionCount * percent);
        }

        internal float CalculateWarehouseQuality()
        {
            var item = WarehouseOutput[ProductDefinition.ItemDefinitionId];
            float existingQuality = item.Quality;
            int existingQuantity = item.Quantity;
            float addedQuality = item.ProcessingQuality;
            int addedQuantity = item.ProcessingQuantity;

            float totalWeight = existingQuantity + addedQuantity;
            if (totalWeight == 0)
                throw new InvalidOperationException("Суммарное количество не может быть нулевым.");

            float weightedSum = existingQuality * existingQuantity + addedQuality * addedQuantity;
            return weightedSum / totalWeight;
        }

    }
}
