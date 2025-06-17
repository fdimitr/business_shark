using System.Linq;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.Items;
using MessagePack;

namespace BusinessShark.Core.CityClasses
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class CityCell
    {
        public class SellIndicator(float attractiveness, int maxSales, Store store)
        {
            public float Attractiveness = attractiveness;
            public int CountOfSell;
            public int MaxSales = maxSales;
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
                if (indicators == null || indicators.Count == 0) continue;

                var totalSales = Convert.ToInt32(Population * market.ItemDefinitions[kvp.Key].Necessity);

                CalculateSalesDistribution(indicators, totalSales);
            }
        }

        internal void CalculateSalesDistribution(List<SellIndicator> indicators, int totalSales)
        {
            int n = indicators.Count;
            var rawSales = new float[n];
            var fulfilled = new bool[n];

            // 1. Сумма всех коэффициентов привлекательности
            float totalAttractiveness = indicators.Sum(i => i.Attractiveness);

            if (totalAttractiveness == 0)
            {
                return;
            }

            // 2. Первичное распределение с округлением вниз
            for (int i = 0; i < n; i++)
            {
                var indicator = indicators[i];
                rawSales[i] = (indicator.Attractiveness / totalAttractiveness) * totalSales;
                indicator.CountOfSell = Math.Min((int)Math.Floor(rawSales[i]), indicator.MaxSales);
                fulfilled[i] = indicator.CountOfSell >= indicator.MaxSales;
            }

            int assignedTotal = indicators.Sum(i=>i.CountOfSell);
            int remaining = totalSales - assignedTotal;

            // 3. Распределяем оставшиеся единицы
            while (remaining > 0)
            {
                

                if (remaining >= n)
                {
                    int actuallyAssigned = remaining / n;

                    for (int i = 0; i < n; i++)
                    {
                        if (fulfilled[i]) continue; // Пропускаем уже заполненные
                        var indicator = indicators[i];
                        if (indicator.MaxSales - indicator.CountOfSell > actuallyAssigned)
                        {
                            indicator.CountOfSell += actuallyAssigned;
                            remaining -= actuallyAssigned;

                        }
                        else
                        {
                            indicator.CountOfSell += indicator.MaxSales - indicator.CountOfSell;
                            remaining -= indicator.MaxSales - indicator.CountOfSell;
                            fulfilled[i] = true; // Отмечаем как выполненное
                        }
                        if (remaining == 0) break; // Если распределили все, выходим
                    }
                }
                else
                {
                    for(int i = 0; i < n; i++)
                    {
                        if (fulfilled[i]) continue;
                        var indicator = indicators[i];
                        indicator.CountOfSell += 1;
                        remaining -= 1;
                        if (indicator.CountOfSell == indicator.MaxSales)
                            fulfilled[i] = true; // Отмечаем как выполненное
                        if (remaining == 0) break; // Если распределили все, выходим
                    }
                }

                var check = 0;
                for(int i = 0; i < n; i++)
                {
                    if (fulfilled[i]) check++;
                }
                if (check == n) break; 
            }

        }
    }
}
