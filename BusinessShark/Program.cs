using BusinessShark.Core;
using BusinessShark.Core.Item;

namespace BusinessShark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bedDefinition = new ItemDefinition(Enums.ItemType.Bed, 1,
            [
                new ProductionUnit(Enums.ItemType.Wood, 5, 0.3f),
                    new ProductionUnit(Enums.ItemType.Leather, 1, 0.1f)
            ], 5, 0.3f, 0.2f, 0.1f);

            var factory = new Factory(bedDefinition, 0, new Tools(), new  Workers());
            factory.WarehouseResources.Add(Enums.ItemType.Wood,
                new Item(new ItemDefinition(Enums.ItemType.Wood, 1, [], 1, 0.3f, 0.3f, 0.4f), 18, 5.0f));
            factory.WarehouseResources.Add(Enums.ItemType.Leather,
                new Item(new ItemDefinition(Enums.ItemType.Leather, 1, [], 1, 0.3f, 0.3f, 0.4f), 20, 2.0f));

            var city = new City("Wroclaw");
            city.Factories.Add(factory);

            Market market = new Market();
            market.Cities.Add(city);

            for (int i = 0; i < 20; i++)
            {
                // Simulate a day in the market
                 market.CalculateDay();
            }
        }
    }
}
