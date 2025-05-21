namespace BusinessShark.Core.Item
{
    internal class Item(ItemDefinition definition, int processingQuantity = 0, float processingQuality = 0, float cena = 0)
    {
        public ItemDefinition Definition = definition;
        public float Quality = 1;
        public int Quantity = 0;
        public float Cena = cena;

        public float ProcessingCena;
        public float ProcessingQuality = processingQuality;
        public int ProcessingQuantity = processingQuantity;
    }
}
