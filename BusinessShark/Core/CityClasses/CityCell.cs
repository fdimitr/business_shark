using System.Linq;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.Item;
using MessagePack;

namespace BusinessShark.Core.CityClasses
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class CityCell
    {
        public class SellIndicator(float attractiveness, Store store)
        {
            public float Attractiveness = attractiveness;
            public int CountOfSell;
            public Store Store = store;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int LandCost { get; set; }
        public int RentCost { get; set; }
        public int Population { get; set; }
        public int Wealth { get; set; }

        public Enums.ResourceType Resource { get; set; }
        public Dictionary<Enums.ItemType, List<SellIndicator>?> SellInfo { get; set; } = new();

        public override string ToString()
        {
            return $"({X},{Y}) | Land: {LandCost}, Rent: {RentCost}, Pop: {Population}, Wealth: {Wealth}, Res: {Resource}";
        }

        public void CalculateLevelSale(Market market)
        {
            foreach (var kvp in SellInfo)
            {
                var indicators = kvp.Value;
                if (indicators == null) continue;

                var itemType = kvp.Key;

                var totalSales = Convert.ToInt32(Population * market.ItemDefinitions[itemType].Necessity);

                float sum = indicators.Sum(i => i.Attractiveness);
                if (sum == 0) return;

                // Step 1: Calculate sales as floating point values
                var rawSales = indicators
                    .Select(a => (a.Attractiveness / sum) * totalSales)
                    .ToList();

                // Step 2: Round down and accumulate the remainder
                var intSales = rawSales.Select(s => Convert.ToInt32(Math.Floor(s))).ToList();
                int assigned = intSales.Sum();
                int remainder = totalSales - assigned;

                // Step 3: Add the remainder to the largest decimal fractions
                var fractionalParts = rawSales
                    .Select((val, index) => new { Index = index, Fraction = val - Math.Floor(val) })
                    .OrderByDescending(x => x.Fraction)
                    .ToList();

                for (int i = 0; i < remainder; i++)
                {
                    intSales[fractionalParts[i].Index]++;
                }

                // Collect the result
                for (int i = 0; i < intSales.Count; i++)
                {
                    var x = indicators[i];
                    x.CountOfSell = intSales[i]; // i — store number (can be replaced with ID if available)
                }
            }
        }
    }
}
