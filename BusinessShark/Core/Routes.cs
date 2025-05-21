using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Routes
    {
        public int FromDivisionId { get; set; }
        public int ToDivisionId { get; set; }
        public Enums.ItemType TransferringItemType { get; set; }
        public int TransferringCount { get; set; }

    }
}
