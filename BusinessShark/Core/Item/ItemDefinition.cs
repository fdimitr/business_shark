using MessagePack;
using static BusinessShark.Core.Item.Enums;

namespace BusinessShark.Core.Item
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class ItemDefinition
    {
        [SerializationConstructor]
        public ItemDefinition(ItemType itemDefinitionId,
            string name,
            float volume,
            float baseProductionCount,
            float techImpactQuality,
            float toolImpactQuality,
            float workerImpactQuality, float sourceImpactQuality, float techImpactQuantity, float toolImpactQuantity, float workerImpactQuantity)
        {
            ItemDefinitionId = itemDefinitionId;
            Name = name;
            Volume = volume;
            BaseProductionCount = baseProductionCount;
            TechImpactQuality = techImpactQuality;
            ToolImpactQuality = toolImpactQuality;
            WorkerImpactQuality = workerImpactQuality;
            SourceImpactQuality = sourceImpactQuality;
            TechImpactQuantity = techImpactQuantity;
            ToolImpactQuantity = toolImpactQuantity;
            WorkerImpactQuantity = workerImpactQuantity;
        }

        public ItemType ItemDefinitionId { get; }
        public string Name { get; }
        public float Volume { get; }
        public List<ProductionUnit> ProductionUnits { get; set; } = new();
        public float BaseProductionCount { get; }

        public float TechImpactQuality { get; }
        public float ToolImpactQuality { get; }
        public float WorkerImpactQuality { get; }
        public float SourceImpactQuality { get; }
        public float TechImpactQuantity { get; }
        public float ToolImpactQuantity { get; }
        public float WorkerImpactQuantity { get; }

        public void CheckTotalImpact()
        {
            var totalImpact = ProductionUnits.Sum(p => p.QualityImpact)
                              + TechImpactQuality
                              + ToolImpactQuality
                              + WorkerImpactQuality
                              + SourceImpactQuality;
            if (Math.Abs(totalImpact - 1) > 0.0001)
                throw new Exception($"Item: {Name}. The total coefficient of influence on quality should be equal to 1. But now it equal to {totalImpact}");
        }

    }

}
