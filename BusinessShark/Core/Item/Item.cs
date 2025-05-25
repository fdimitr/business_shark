using MessagePack;

namespace BusinessShark.Core.Item
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Item
    {
        public ItemDefinition Definition;
        public float Quality;
        public int Quantity;
        public float Cena;

        public float ProcessingCena;
        public float ProcessingQuality;
        public int ProcessingQuantity;

        [SerializationConstructor]
        public Item(ItemDefinition definition, float processingQuality = 0, int processingQuantity = 0, int quantity = 0, float quality = 0, float cena = 0)
        {
            Definition = definition;
            Quality = quality;
            Quantity = quantity;
            Cena = cena;
            ProcessingQuality = processingQuality;
            ProcessingQuantity = processingQuantity;
        }

        public void ResetProcessing()
        {
            ProcessingQuality = 0;
            ProcessingQuantity = 0;
        }
    }
}
