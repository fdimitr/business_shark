namespace BusinessShark.Core.Item
{
    internal class ProductionUnit(Enums.ItemType itemType, int productionQuantity, float qualityImpact)
    {
        public Enums.ItemType ItemType { get; } = itemType;
        public int ProductionQuantity { get; } = productionQuantity;
        public float QualityImpact { get; } = qualityImpact;
    }
}
