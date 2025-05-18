using static BusinessShark.Core.Item.Enums;

namespace BusinessShark.Core.Item
{
    internal class ItemDefinition
    {
        public ItemDefinition(ItemType itemType,
            float volume,
            ProductionUnit[] productionUnits,
            float productionCount,
            float techImpact,
            float toolImpact,
            float workerImpact)
        {
            ItemType = itemType;
            Volume = volume;
            ProductionUnits = productionUnits;
            IdealProductionCount = productionCount;
            TechImpact = techImpact;
            ToolImpact = toolImpact;
            WorkerImpact = workerImpact;

            var totalImpact = (productionUnits != null ? productionUnits.Sum(p => p.QualityImpact) : 0)
                              + techImpact
                              + toolImpact
                              + workerImpact;
            if (Math.Abs(totalImpact - 1) > 0.0001)
                throw new Exception("The total coefficient of influence on quality should be equal to 1");
        }

        public ItemType ItemType { get; }
        public float Volume { get; }
        public ProductionUnit[] ProductionUnits { get; }
        public float IdealProductionCount { get; }

        public float TechImpact { get; }
        public float ToolImpact { get; }
        public float WorkerImpact { get; }
    }
}
