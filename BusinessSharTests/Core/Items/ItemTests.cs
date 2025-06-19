using BusinessShark.Core;
using BusinessShark.Core.CityClasses;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.Items;
using BusinessShark.Core.ServiceClasses;
using static BusinessShark.Core.Enums;

namespace BusinessSharkTests.Core.Items
{
    [TestFixture]
    public class ItemTests
    {
        private ItemDefinition CreateItemDefinition(float maxPriceThreshold = 100f)
        {
            return new ItemDefinition(
                ItemType.Bed,
                "TestItem",
                1f,
                1f,
                0.1f,
                0.1f,
                0.1f,
                0.1f,
                0.1f,
                0.1f,
                0.1f,
                10f,
                1f,
                0.5f
            )
            {
                MaxPriceThreshold = maxPriceThreshold
            };
        }

        private Store CreateStore(float recognitionLevel = 0.5f, float techLevel = 0.5f)
        {
            return new Store(1, "TestStore", new Location(0, 0), new List<CityCell>())
            {
                RecognitionLevel = recognitionLevel,
                Workers = new Workers { TechLevel = techLevel }
            };
        }

        [Test]
        public void CalculateAttractiveness_ReturnsExpectedValue_WithTypicalInputs()
        {
            var definition = CreateItemDefinition(maxPriceThreshold: 100f);
            var item = new Item(definition, quality: 0.8f, price: 50f)
            {
                AdvertisingRecognition = 0.6f
            };
            var store = CreateStore(0.7f, 0.9f);

            float expectedNormalizedPrice = 1.0f - (50f / 100f); // 0.5
            float expected = (expectedNormalizedPrice * 0.35f) +
                             (0.8f * 0.25f) +
                             (0.6f * 0.15f) +
                             (0.7f * 0.15f) +
                             (0.9f * 0.10f);

            float result = item.CalculateAttractiveness(store);

            Assert.That(result, Is.EqualTo(expected).Within(0.0001f));
        }

        [Test]
        public void CalculateAttractiveness_ClampsNormalizedPrice_ToZero()
        {
            var definition = CreateItemDefinition(maxPriceThreshold: 100f);
            var item = new Item(definition, quality: 0.5f, price: 200f)
            {
                AdvertisingRecognition = 0.2f
            };
            var store = CreateStore(0.3f, 0.4f);

            // Price is above max threshold, so normalizedPrice should clamp to 0
            float expected = (0f * 0.35f) +
                             (0.5f * 0.25f) +
                             (0.2f * 0.15f) +
                             (0.3f * 0.15f) +
                             (0.4f * 0.10f);

            float result = item.CalculateAttractiveness(store);

            Assert.That(result, Is.EqualTo(expected).Within(0.0001f));
        }

        [Test]
        public void CalculateAttractiveness_ClampsNormalizedPrice_ToOne()
        {
            var definition = CreateItemDefinition(maxPriceThreshold: 100f);
            var item = new Item(definition, quality: 0.3f, price: -10f)
            {
                AdvertisingRecognition = 0.1f
            };
            var store = CreateStore(0.2f, 0.3f);

            // Price is negative, so normalizedPrice should clamp to 1
            float expected = (1f * 0.35f) +
                             (0.3f * 0.25f) +
                             (0.1f * 0.15f) +
                             (0.2f * 0.15f) +
                             (0.3f * 0.10f);

            float result = item.CalculateAttractiveness(store);

            Assert.That(result, Is.EqualTo(expected).Within(0.0001f));
        }

        [Test]
        public void CalculateAttractiveness_ZeroInputs_ReturnsWeightedSum()
        {
            var definition = CreateItemDefinition(maxPriceThreshold: 100f);
            var item = new Item(definition, quality: 0f, price: 0f)
            {
                AdvertisingRecognition = 0f
            };
            var store = CreateStore(0f, 0f);

            float expected = (1f * 0.35f) + // normalizedPrice = 1
                             (0f * 0.25f) +
                             (0f * 0.15f) +
                             (0f * 0.15f) +
                             (0f * 0.10f);

            float result = item.CalculateAttractiveness(store);

            Assert.That(result, Is.EqualTo(expected).Within(0.0001f));
        }
    }
}
