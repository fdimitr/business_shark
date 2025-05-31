using BusinessShark.Core.Item;

namespace BusinessShark.Database.Models
{
    internal class ProductionUnitDto
    {
        public int ProductDefinitionId { get; set; }
        public int ComponentDefinitionId { get; set; }
        public int ProductionQuantity { get; set; }
        public float QualityImpact { get; set; }
    }
}
