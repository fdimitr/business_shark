using static BusinessShark.Core.Item.Enums;

namespace BusinessShark.Core.Item
{
    internal class ItemDefinition(
        ItemType itemType,
        float volume,
        ProductionUnit[] productionUnits,
        float productionCount)
    {
        public ItemType ItemType { get; } = itemType;
        public float Volume { get; } = volume;
        public ProductionUnit[] ProductionUnits { get; } = productionUnits;
        public float IdealProductionCount { get; } = productionCount;
    }
}
