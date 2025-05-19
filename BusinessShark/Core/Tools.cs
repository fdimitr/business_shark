namespace BusinessShark.Core
{
    internal class Tools
    {
        public int TotalQuantity;
        public float TechLevel;
        public float Deprecation;

        public int ActiveQuantity => (int)Math.Round(TotalQuantity * Deprecation);
    }
}
