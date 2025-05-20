using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Factory(ItemDefinition productDefinition, float techLevel, Tools toolPark, Workers workers)
    {
        public ItemDefinition ProductDefinition = productDefinition;
        public float ProgressProduction;
        public float ProgressQuality;
        public float TechLevel = techLevel;
        public Tools ToolPark = toolPark;
        public Workers FactoryWorkers = workers;

        public Dictionary<Enums.ItemType, Item.Item> WarehouseProducts = new();
        public Dictionary<Enums.ItemType, Item.Item> WarehouseResources = new();

        public void Production()
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
                        var item = WarehouseResources[unit.ComponentDefinitionId];
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

            ProgressProduction += ProductDefinition.ProductionCount;

            // Completion of production
            if (ProgressProduction >= 1)
            {
                var productionCount = (int)Math.Round(ProgressProduction);

                if (WarehouseProducts.TryGetValue(ProductDefinition.ItemDefinitionId, out Item.Item? storedItem))
                {
                    storedItem.Quality = CalculateWarehouseQuality(storedItem.Quality, storedItem.Quantity,
                        ProgressQuality, productionCount);
                    WarehouseProducts[ProductDefinition.ItemDefinitionId].Quantity += productionCount;
                }
                else
                {
                    WarehouseProducts[ProductDefinition.ItemDefinitionId] =
                        new Item.Item(ProductDefinition, productionCount, ProgressQuality);
                }

                // Reset progress
                ProgressProduction = 0;
                ProgressQuality = 0;
            }
        }

        private bool PossibleToProduce()
        {
            foreach (var unit in ProductDefinition.ProductionUnits)
            {
                WarehouseResources.TryGetValue(unit.ComponentDefinitionId, out Item.Item? item);
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
                throw new InvalidOperationException("Суммарное влияние не может быть равно нулю.");

            var numerator = items.Sum(e => e.Quality * ProductDefinition.ProductionUnits.First(p => p.ComponentDefinitionId == e.Definition.ItemDefinitionId).QualityImpact)
                            + TechLevel * ProductDefinition.TechImpactQuality
                            + ToolPark.TechLevel * ProductDefinition.ToolImpactQuality
                            + FactoryWorkers.TechLevel * ProductDefinition.WorkerImpactQuality;
            return numerator / totalImpact;
        }

        internal static float CalculateWarehouseQuality(float existingQuality, int existingQuantity,
            float addedQuality, int addedQuantity)
        {
            float totalWeight = existingQuantity + addedQuantity;
            if (totalWeight == 0)
                throw new InvalidOperationException("Суммарное количество не может быть нулевым.");

            float weightedSum = existingQuality * existingQuantity + addedQuality * addedQuantity;
            return weightedSum / totalWeight;
        }
    }
}
