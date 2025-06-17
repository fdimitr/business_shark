using System.Linq;
using BusinessShark.Core.Divisions;
using BusinessShark.Core.Items;
using MessagePack;

namespace BusinessShark.Core.CityClasses
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class CityCell
    {
        public class SellIndicator(float attractiveness, int maxSales)
        {
            public float Attractiveness = attractiveness;
            public int CountOfSell;
            public int MaxSales = maxSales;
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
                // Пересчитываем "оставшиеся" магазины (те, кто не достиг лимита)
                /*
                var eligible = Enumerable.Range(0, n)
                    .Where(i => !fulfilled[i])
                    .Select(i => new
                    {
                        Index = i,
                        Weight = indicators[i].Attractiveness
                    })
                    .ToList();

                float subTotalAttractiveness = eligible.Sum(e => e.Weight);
                if (subTotalAttractiveness == 0 || !eligible.Any())
                    break; // Никто больше не может продать

                
                // Пытаемся перераспределить остаток
                var additionalSales = new int[n];
                foreach (var e in eligible)
                {
                    float ratio = e.Weight / subTotalAttractiveness;
                    int extra = (int)Math.Floor(ratio * remaining);
                    int capacityLeft = indicators[e.Index].MaxSales - indicators[e.Index].CountOfSell;
                    int toAssign = Math.Min(extra, capacityLeft);
                    additionalSales[e.Index] += toAssign;
                }
                */

                // Обновляем продажи и пересчитываем остаток
                if (remaining >= n)
                {
                    int actuallyAssigned = remaining / n;

                    for (int i = 0; i < n; i++)
                    {
                        if (fulfilled[i]) continue; // Пропускаем уже заполненные
                        if (indicators[i].MaxSales - indicators[i].CountOfSell > actuallyAssigned)
                        {
                            indicators[i].CountOfSell += actuallyAssigned;
                            remaining -= actuallyAssigned;

                        }
                        else
                        {
                            indicators[i].CountOfSell += indicators[i].MaxSales - indicators[i].CountOfSell;
                            remaining -= indicators[i].MaxSales - indicators[i].CountOfSell;
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
                        indicators[i].CountOfSell += 1;
                        remaining -= 1;
                        if (indicators[i].CountOfSell == indicators[i].MaxSales)
                            fulfilled[i] = true; // Отмечаем как выполненное
                        if (remaining == 0) break; // Если распределили все, выходим
                    }
                }

                var check = 0;
                for(int i = 0; i < n; i++)
                {
                    
                    if (fulfilled[i]) check++;
                }
                if (check == n) break; //свободного места во всех магазинах нет

                /*
                remaining -= actuallyAssigned;

                // Если никому не удалось распределить — прерываем, чтобы избежать бесконечного цикла
                if (actuallyAssigned == 0)
                    break;
                */
            }

        }
    }
}
