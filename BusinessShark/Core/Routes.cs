using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Routes
    {
        public DeliveryDivision? FromDivision { get; set; }
        public DeliveryDivision? ToDivision { get; set; }
        public Enums.ItemType TransferringItemType { get; set; }
        public int TransferringCount { get; set; }

    }
}
