using System.Diagnostics;
using BusinessShark.Core.CityClasses;

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
                    indicators.Add(new CityCell.SellIndicator(attractiveness, maxSales));
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
                    indicatorsCopy.Add(new CityCell.SellIndicator(ind.Attractiveness, ind.MaxSales));
                cell.CalculateSalesDistribution(indicatorsCopy, totalSalesList[i]);
            }
            sw.Stop();

            Assert.Pass($"Total execution time for 1,000,000 CalculateSalesDistribution calls: {sw.Elapsed} ms");
        }
    }
}