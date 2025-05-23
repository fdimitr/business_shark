using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Routes(
        DeliveryDivision fromDivision,
        DeliveryDivision toDivision,
        Enums.ItemType transferringItemType,
        int transferringCount)
    {
        public DeliveryDivision FromDivision { get; set; } = fromDivision;
        public DeliveryDivision ToDivision { get; set; } = toDivision;
        public Enums.ItemType TransferringItemType { get; set; } = transferringItemType;
        public int TransferringCount { get; set; } = transferringCount;
    }
}
