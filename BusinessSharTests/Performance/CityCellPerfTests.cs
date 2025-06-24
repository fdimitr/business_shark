using System.Diagnostics;
using BusinessShark.Core;
using BusinessShark.Core.CityClasses;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.ServiceClasses;

namespace BusinessSharkTests.Performance
{
    [TestFixture]
    public class CityCellPerfTest
    {
        [Test]
        public void RunSalesDistributionPerfTest()
        {
            var cell = new CityCell();
            var rand = new Random(42);
            var store = new Store(1, "Test Store", new Location(1, 1, new City(string.Empty, 10, 10)),
                Enums.SizeType.OneByTwo, [new CityCell(), new CityCell(), new CityCell()]);
            var totalRuns = 1_000_000;
            var indicatorsList = new List<List<CityCell.SellIndicator>>(totalRuns);
            var totalSalesList = new int[totalRuns];

            // Prepare 100,000 different inputs
            for (int i = 0; i < totalRuns; i++)
            {
                int n = rand.Next(2, 6); // 2 to 5 indicators
                var indicators = new List<CityCell.SellIndicator>(n);
                for (int j = 0; j < n; j++)
                {
                    float attractiveness = (float)(rand.NextDouble() * 10 + 1);
                    int maxSales = rand.Next(100, 1000);
                    indicators.Add(new CityCell.SellIndicator(attractiveness, maxSales, store));
                }
                indicatorsList.Add(indicators);
                totalSalesList[i] = rand.Next(100, 2000);
            }

            var sw = Stopwatch.StartNew();
            for (int i = 0; i < totalRuns; i++)
            {
                // Use a new list instance each time to avoid side effects
                var indicatorsCopy = new List<CityCell.SellIndicator>();
                foreach (var ind in indicatorsList[i])
                    indicatorsCopy.Add(new CityCell.SellIndicator(ind.Attractiveness, ind.MaxSales, store));
                cell.CalculateSalesDistribution(indicatorsCopy, totalSalesList[i]);
            }
            sw.Stop();

            Assert.Pass($"Total execution time for 1,000,000 CalculateSalesDistribution calls: {sw.Elapsed} ms");
        }
    }
}