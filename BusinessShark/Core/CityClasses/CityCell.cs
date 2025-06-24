using BusinessShark.Core.Divisions;
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
        public int? DivisionId { get; private set; }

        public Enums.ResourceType Resource { get; set; }

         public Dictionary<Enums.ItemType, List<SellIndicator>?> SellInfo { get; set; } = new();

        public override string ToString()
        {
            return $"({X},{Y}) | Land: {LandCost}, Rent: {RentCost}, Pop: {Population}, Wealth: {Wealth}, Res: {Resource}";
        }

        public void SetDivision(int divisionId, bool shouldPopulationEvict)
        {
            if (DivisionId.HasValue)
            {
                throw new InvalidOperationException($"Cell at ({X},{Y}) already has a division with ID {DivisionId.Value}.");
            }

            DivisionId = divisionId;
            if (shouldPopulationEvict) Population = 0;
        }

        public void DestroyDivision()
        {
            DivisionId = null;
            Population = 0; // Reset population when division is destroyed
        }

        /// <summary>
        /// Calculates and distributes the sales levels for each item type in the cell based on the market's item definitions and the cell's population.
        /// For each item type, determines the total possible sales using the necessity coefficient and delegates the distribution to <see cref="CalculateSalesDistribution"/>.
        /// </summary>
        /// <param name="market">The market context containing item definitions and necessity coefficients.</param>
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


        /// <summary>
        /// Distributes the total number of sales among the provided <see cref="SellIndicator"/> instances
        /// based on their attractiveness and maximum sales constraints.
        /// The distribution is performed in two steps:
        /// 1. Proportional allocation according to attractiveness, limited by MaxSales.
        /// 2. Remaining sales are distributed in a round-robin fashion, respecting MaxSales limits.
        /// </summary>
        /// <param name="indicators">The list of <see cref="SellIndicator"/> objects to distribute sales to.</param>
        /// <param name="totalSales">The total number of sales to distribute among the indicators.</param>
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

            int assignedTotal = indicators.Sum(i => i.CountOfSell);
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
                    for (int i = 0; i < n; i++)
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
                for (int i = 0; i < n; i++)
                {
                    if (fulfilled[i]) check++;
                }
                if (check == n) break;
            }
        }
    }
}
