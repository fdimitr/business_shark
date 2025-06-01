using MessagePack;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Workers
    {
        public int TotalQuantity;
        public float TechLevel = 1;
    }
}
