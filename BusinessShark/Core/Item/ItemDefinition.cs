using System.ComponentModel.DataAnnotations.Schema;
using static BusinessShark.Core.Item.Enums;

namespace BusinessShark.Core.Item
{
    internal class ItemDefinition
    {
        public ItemDefinition(int itemDefinitionId,
            string name,
            float volume,
            float productionCount,
            float techImpactQuality,
            float toolImpactQuality,
            float workerImpactQuality, float sourceImpactQuality, float techImpactQuantity, float toolImpactQuantity, float workerImpactQuantity)
        {
            ItemDefinitionId = (ItemType)itemDefinitionId;
            Name = name;
            Volume = volume;
            ProductionCount = productionCount;
            TechImpactQuality = techImpactQuality;
            ToolImpactQuality = toolImpactQuality;
            WorkerImpactQuality = workerImpactQuality;
            SourceImpactQuality = sourceImpactQuality;
            TechImpactQuantity = techImpactQuantity;
            ToolImpactQuantity = toolImpactQuantity;
            WorkerImpactQuantity = workerImpactQuantity;

            //var totalImpact = (productionUnits != null ? productionUnits.Sum(p => p.QualityImpact) : 0)
            //                  + techImpactQuality
            //                  + toolImpactQuality
            //                  + workerImpactQuality;
            //if (Math.Abs(totalImpact - 1) > 0.0001)
            //    throw new Exception("The total coefficient of influence on quality should be equal to 1");
        }

        public ItemType ItemDefinitionId { get; }
        public string Name { get; }
        public float Volume { get; }
        public List<ProductionUnit> ProductionUnits { get; set; } = new();
        public float ProductionCount { get; }

        public float TechImpactQuality { get; }
        public float ToolImpactQuality { get; }
        public float WorkerImpactQuality { get; }
        public float SourceImpactQuality { get; }
        public float TechImpactQuantity { get; }
        public float ToolImpactQuantity { get; }
        public float WorkerImpactQuantity { get; }

    }

}
