using BusinessShark.Core.Divisions;
using MessagePack;

namespace BusinessShark.Core.Items
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

        public float AdvertisingRecognition { get; set; }

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

        public float CalculateAttractiveness(Store store)
        {
            // Define weights (sum = 1.0 for normalization)
            const float weightPrice = 0.35f;
            const float weightQuality = 0.25f;
            const float weightProductAd = 0.15f;
            const float weightStoreAd = 0.15f;
            const float weightEmployeeLevel = 0.10f;

            // Normalize price attractiveness (invert: lower price = higher attractiveness)
            // Assume a practical price range [0, MaxPriceThreshold]
            float normalizedPrice = 1.0f - (Price / Definition.MaxPriceThreshold);
            normalizedPrice = Math.Clamp(normalizedPrice, 0, 1); // Ensure within [0,1]

            // Calculate weighted sum
            float attractiveness =
                (normalizedPrice * weightPrice) +
                (Quality * weightQuality) +
                (AdvertisingRecognition * weightProductAd) +
                (store.RecognitionLevel * weightStoreAd) +
                (store.Workers.TechLevel * weightEmployeeLevel);

            return attractiveness;
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
