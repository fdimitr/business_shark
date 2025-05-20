namespace BusinessShark.Core.Item
{
    internal class ProductionUnit(long productDefinitionId, long itemDefinitionId, long productionQuantity, double qualityImpact)
    {
        public Enums.ItemType ComponentDefinitionId { get; } = (Enums.ItemType)productDefinitionId;
        public Enums.ItemType ItemDefinitionId { get; } = (Enums.ItemType)itemDefinitionId;
        public int ProductionQuantity { get; } = (int)productionQuantity;
        public float QualityImpact { get; } = (float)qualityImpact;
    }
}
