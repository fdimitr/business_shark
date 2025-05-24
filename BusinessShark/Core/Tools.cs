namespace BusinessShark.Core
{
    [Serializable]
    internal class Tools
    {
        public int TotalQuantity;
        public float TechLevel = 1;
        public float Deprecation;

        public int ActiveQuantity => (int)Math.Round(TotalQuantity * Deprecation);
    }
}
