using MessagePack;

namespace BusinessShark.Core.Items
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class ProductionUnit
    {
        [SerializationConstructor]
        public ProductionUnit(Enums.ItemType productDefinitionId, Enums.ItemType componentDefinitionId, int productionQuantity, float qualityImpact)
        {
            ProductDefinitionId = productDefinitionId;
            ComponentDefinitionId = componentDefinitionId;
            ProductionQuantity = productionQuantity;
            QualityImpact = qualityImpact;
        }

        public Enums.ItemType ProductDefinitionId { get; }
        public Enums.ItemType ComponentDefinitionId { get; }
        public int ProductionQuantity { get; }
        public float QualityImpact { get; }
    }
}
