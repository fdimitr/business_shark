namespace BusinessShark.Core.Item
{
    internal class Item(ItemDefinition definition, int quantity = 0, float quality = 0)
    {
        public ItemDefinition Definition = definition;
        public float Quality = quality;
        public int Quantity = quantity;
    }
}
