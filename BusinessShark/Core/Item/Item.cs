using MessagePack;

namespace BusinessShark.Core.Item
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Item : ICloneable
    {
        public ItemDefinition Definition;
        public float Quality;
        public int Quantity;
        public float Price;

        public float ProcessingPrice;
        public float ProcessingQuality;
        public int ProcessingQuantity;

        [SerializationConstructor]
        public Item(ItemDefinition definition, float processingQuality = 0, int processingQuantity = 0, int quantity = 0, float quality = 0, float price = 0)
        {
            Definition = definition;
            Quality = quality;
            Quantity = quantity;
            Price = price;
            ProcessingQuality = processingQuality;
            ProcessingQuantity = processingQuantity;
        }

        public object Clone()
        {
            // ItemDefinition is assumed to be immutable or shared, so shallow copy is fine
            return new Item(
                Definition,
                ProcessingQuality,
                ProcessingQuantity,
                Quantity,
                Quality,
                Price
            )
            {
                ProcessingPrice = this.ProcessingPrice
            };
        }

        public void ResetProcessing()
        {
            ProcessingQuality = 0;
            ProcessingQuantity = 0;
            ProcessingPrice = 0;
        }
    }
}
