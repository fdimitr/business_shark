using BusinessShark.Core.Item;
using MessagePack;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Routes(int fromDivisionId, Enums.ItemType transferringItemType, int transferringCount)
    {
        public int FromDivisionId { get; set; } = fromDivisionId;
        public Enums.ItemType TransferringItemType { get; set; } = transferringItemType;
        public int TransferringCount { get; set; } = transferringCount;
    }
}
