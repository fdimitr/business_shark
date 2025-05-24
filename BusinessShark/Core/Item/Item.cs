namespace BusinessShark.Core.Item
{
    [Serializable]
    internal class Item(ItemDefinition definition, float processingQuality = 0, int processingQuantity = 0, int quantity = 0, float quality = 0, float cena = 0)
    {
        public ItemDefinition Definition = definition;
        public float Quality = quality;
        public int Quantity = quantity;
        public float Cena = cena;

        public float ProcessingCena;
        public float ProcessingQuality = processingQuality;
        public int ProcessingQuantity = processingQuantity;

        public void ResetProcessing()
        {
            ProcessingQuality = 0;
            ProcessingQuantity = 0;
        }
    }
}
