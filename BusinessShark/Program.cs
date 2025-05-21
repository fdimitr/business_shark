using System.Drawing;
using BusinessShark.Core;
using BusinessShark.Core.Item;

namespace BusinessShark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();

            var factory = new Factory(1, market.ItemDefinitions[Enums.ItemType.Bed], 1, new Tools(), new  Workers(), new Point(100, 100));
            factory.WarehouseResources.Add(Enums.ItemType.Wood,
                new Item(market.ItemDefinitions[Enums.ItemType.Wood], 18, 5.0f));
            factory.WarehouseResources.Add(Enums.ItemType.Leather,
                new Item(market.ItemDefinitions[Enums.ItemType.Leather], 20, 2.0f));

            var city = new City("Wroclaw");
            city.Factories.Add(factory);

            market.Cities.Add(city);

            for (int i = 0; i < 20; i++)
            {
                // Simulate a day in the market
                 market.CalculateDay();
            }
        }
    }
}
