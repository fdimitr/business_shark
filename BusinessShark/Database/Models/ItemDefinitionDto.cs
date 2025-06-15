using BusinessShark.Core.Item;
using static BusinessShark.Core.Item.Enums;

namespace BusinessShark.Database.Models
{
    internal class ItemDefinitionDto
    {
        public int ItemDefinitionId { get; set; }
        public required string Name { get; set; }
        public float Volume { get; set; }
        public List<ProductionUnitDto> ProductionUnits { get; set; } = new();
        public float ProductionCount { get; set; }

        public float TechImpactQuality { get; set; }
        public float ToolImpactQuality { get; set; }
        public float WorkerImpactQuality { get; set; }
        public float SourceImpactQuality { get; set; }
        public float TechImpactQuantity { get; set; }
        public float ToolImpactQuantity { get; set; }
        public float WorkerImpactQuantity { get; set; }

        public float ProductionPrice { get; set; }

        public float DeliveryPrice { get; set; }
        public float Necessity { get; set; }

    }
}
