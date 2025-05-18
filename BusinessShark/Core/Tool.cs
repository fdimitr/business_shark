namespace BusinessShark.Core
{
    internal class Tool
    {
        public int TotalQuantity;
        public float TechLevel;
        public float Deprecation;

        public int ActiveQuantity => (int)Math.Round(TotalQuantity * Deprecation);
    }
}
