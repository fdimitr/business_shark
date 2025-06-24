using BusinessShark.Core;
using BusinessShark.Core.CityClasses;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.ServiceClasses;

namespace BusinessSharkTests.Core.CityClasses
{
    [TestFixture]
    public class CityCellTests
    {
        private CityCell _cell;
        private Store _store;

        [SetUp]
        public void SetUp()
        {
            _store = new Store(1, "Test Store", new Location(1, 1, new City(String.Empty, 5, 5)), Enums.SizeType.OneByOne,
                [new CityCell(), new CityCell(), new CityCell()]);
            _cell = new CityCell();
        }

        [Test]
        public void CalculateSalesDistribution_SingleIndicator_AssignsAllSalesUpToMax()
        {
            var indicators = new List<CityCell.SellIndicator>
            {
                new(1.0f, 10, _store)
            };

            _cell.CalculateSalesDistribution(indicators, 8);

            Assert.That(indicators[0].CountOfSell, Is.EqualTo(8));
        }

        [Test]
        public void CalculateSalesDistribution_SingleIndicator_RespectsMaxSales()
        {
            var indicators = new List<CityCell.SellIndicator>
            {
                new(1.0f, 5, _store)
            };

            _cell.CalculateSalesDistribution(indicators, 10);

            Assert.That(indicators[0].CountOfSell, Is.EqualTo(5));
        }

        [Test]
        public void CalculateSalesDistribution_MultipleIndicators_ProportionalDistribution()
        {
            var indicators = new List<CityCell.SellIndicator>
            {
                new(2.0f, 10, _store),
                new(1.0f, 10, _store)
            };

            _cell.CalculateSalesDistribution(indicators, 9);

            // 2/3 of 9 = 6, 1/3 of 9 = 3
            Assert.That(indicators[0].CountOfSell, Is.EqualTo(6));
            Assert.That(indicators[1].CountOfSell, Is.EqualTo(3));
        }

        [Test]
        public void CalculateSalesDistribution_MultipleIndicators_WithMaxSalesLimits()
        {
            var indicators = new List<CityCell.SellIndicator>
            {
                new(2.0f, 4, _store),
                new(1.0f, 10, _store)
            };

            _cell.CalculateSalesDistribution(indicators, 9);

            // First gets max 4, second gets the rest (5)
            Assert.That(indicators[0].CountOfSell, Is.EqualTo(4));
            Assert.That(indicators[1].CountOfSell, Is.EqualTo(5));
        }

        [Test]
        public void CalculateSalesDistribution_ZeroAttractiveness_NoSales()
        {
            var indicators = new List<CityCell.SellIndicator>
            {
                new(0.0f, 10, _store),
                new(0.0f, 10, _store)
            };

            _cell.CalculateSalesDistribution(indicators, 10);

            Assert.That(indicators[0].CountOfSell, Is.EqualTo(0));
            Assert.That(indicators[1].CountOfSell, Is.EqualTo(0));
        }

        [Test]
        public void CalculateSalesDistribution_ExtraSales_DistributedToEligible()
        {
            var indicators = new List<CityCell.SellIndicator>
            {
                new(1.0f, 2, _store),
                new(1.0f, 10, _store)
            };

            _cell.CalculateSalesDistribution(indicators, 5);

            // First gets max 2, second gets the rest (3)
            Assert.That(indicators[0].CountOfSell, Is.EqualTo(2));
            Assert.That(indicators[1].CountOfSell, Is.EqualTo(3));
        }

        [Test]
        public void CalculateSalesDistribution_RoundingBehavior()
        {
            var indicators = new List<CityCell.SellIndicator>
            {
                new(1.0f, 10, _store),
                new(1.0f, 10, _store),
                new(1.0f, 10, _store)
            };

            _cell.CalculateSalesDistribution(indicators, 10);

            // Each should get 3, 3, 4 (since 10/3 = 3.33, so two get 3, one gets 4)
            var total = 0;
            foreach (var ind in indicators)
                total += ind.CountOfSell;

            Assert.That(total, Is.EqualTo(10));
            Assert.That(indicators[0].CountOfSell + indicators[1].CountOfSell + indicators[2].CountOfSell, Is.EqualTo(10));
            Assert.That(indicators[0].CountOfSell, Is.GreaterThanOrEqualTo(3));
            Assert.That(indicators[1].CountOfSell, Is.GreaterThanOrEqualTo(3));
            Assert.That(indicators[2].CountOfSell, Is.GreaterThanOrEqualTo(3));
        }
    }
}
