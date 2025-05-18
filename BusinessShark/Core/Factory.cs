using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Factory
    {
        public ItemDefinition ProductDefinition;
        public float ProgressProduction;
        public float ProgressQuality;
        public float TechLevel;
        public Tool ToolPark;

        public Dictionary<Enums.ItemType, Item.Item> WarehouseProducts = new();
        public Dictionary<Enums.ItemType, Item.Item> WarehouseResources = new();

        public Factory(ItemDefinition productDefinition, float techLevel, Tool toolPark)
        {
            ProductDefinition = productDefinition;
            TechLevel = techLevel;
            ToolPark = toolPark;
        }

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
                        var item = WarehouseResources[unit.ItemType];
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

            ProgressProduction += ProductDefinition.IdealProductionCount;

            // Completion of production
            if (ProgressProduction >= 1)
            {
                var productionCount = (int)Math.Round(ProgressProduction);

                if (WarehouseProducts.TryGetValue(ProductDefinition.ItemType, out Item.Item? storedItem))
                {
                    storedItem.Quality = CalculateWarehouseQuality(storedItem.Quality, storedItem.Quantity,
                        ProgressQuality, productionCount);
                    WarehouseProducts[ProductDefinition.ItemType].Quantity += productionCount;
                }
                else
                {
                    WarehouseProducts[ProductDefinition.ItemType] =
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
                WarehouseResources.TryGetValue(unit.ItemType, out Item.Item? item);
                if (item == null || item.Quantity < unit.ProductionQuantity)
                    return false;
            }
            return true;
        }

        private float CalculateProductionQuality(List<Item.Item> items)
        {
            float totalImpact = ProductDefinition.ProductionUnits.Sum(e => e.QualityImpact);

            if (totalImpact == 0)
                throw new InvalidOperationException("Суммарное влияние не может быть равно нулю.");

            var numerator = items.Sum(e => e.Quality * e.Quantity * ProductDefinition.ProductionUnits.First(p => p.ItemType == e.Definition.ItemType).QualityImpact);
            var denominator = items.Sum(e => e.Quantity * ProductDefinition.ProductionUnits.First(p => p.ItemType == e.Definition.ItemType).QualityImpact);
            return numerator / denominator;
        }

        public static float CalculateWarehouseQuality(float existingQuality, int existingQuantity,
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
