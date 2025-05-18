namespace BusinessShark.Core
{
    internal class Market
    {
        public List<City> Cities = new();

        public void CalculateDay()
        {
            foreach (var city in Cities)
            {
                foreach (var factory in city.Factories)
                {
                    factory.Production();
                }
            }
        }
    }
}
