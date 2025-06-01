using MessagePack;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Tools
    {
        public int TotalQuantity;
        public float TechLevel = 1;
        public float Deprecation;

        [IgnoreMember]
        public int ActiveQuantity => (int)Math.Round(TotalQuantity * Deprecation);
    }
}
