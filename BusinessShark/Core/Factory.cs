using System.Drawing;
using System.Text.Json.Serialization;
using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    [Serializable]
    [method: JsonConstructor]
    internal class Factory(
        int divisionId,
        string name,
        ItemDefinition? productDefinition,
        float techLevel,
        Tools toolPark,
        Workers workers,
        Point location) : DeliveryDivision(divisionId, name, location)
    {
        [Serializable]
        internal struct QualityItem(float quality, float qualityImpact)
        {
            public float Quality = quality;
            public float QualityImpact = qualityImpact;
        }

        public ItemDefinition? ProductDefinition { get; set; } = productDefinition;
        public float ProgressProduction { get; set; } // Percent of single product left on production
        public float ProgressQuality { get; set; }
        public float TechLevel { get; set; } = techLevel;
        public Tools ToolPark { get; set; } = toolPark;
        public Workers FactoryWorkers { get; set; } = workers;
        private bool isProductionCompleted { get; set; } = true;

        public override void StartCalculation()
        {
            if (ProductDefinition == null || WarehouseInput.Count == 0)
            {
                return; // No product to produce or no resources available
            }

            float cycleProgressQuality = 0;

            if (isProductionCompleted)
            {
                isProductionCompleted = false;

                // Start production
                if (PossibleToProduce())
                {
                    // Take resources for production
                    var listForQualityCalc = new List<QualityItem>();
                    foreach (var unit in ProductDefinition.ProductionUnits ?? Enumerable.Empty<ProductionUnit>())
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
            if (ProductDefinition != null && WarehouseOutput.TryGetValue(ProductDefinition.ItemDefinitionId, out var item))
            {
                var newQuality = CalculateWarehouseQuality(item);

                item.Quantity += item.ProcessingQuantity;
                item.Quality = newQuality;

                item.ResetProcessing();
            }
        }

        private bool PossibleToProduce()
        {
            if (ProductDefinition == null) return false;

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
            if (ProductDefinition != null)
            {
                return qualityItems.Sum(e => e.Quality * e.QualityImpact)
                       + TechLevel * ProductDefinition.TechImpactQuality
                       + ToolPark.TechLevel * ProductDefinition.ToolImpactQuality
                       + FactoryWorkers.TechLevel * ProductDefinition.WorkerImpactQuality;
            }

            return 0;
        }

        internal float CalculateProductionQuantity(float baseProductionCount)
        {
            if (ProductDefinition != null)
            {
                var quantity = TechLevel * ProductDefinition.TechImpactQuantity
                               + ToolPark.TechLevel * ProductDefinition.ToolImpactQuantity
                               + FactoryWorkers.TechLevel * ProductDefinition.WorkerImpactQuantity;
                return baseProductionCount * quantity;
            }

            return 0;
        }
    }
}
