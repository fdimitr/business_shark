using BusinessShark.Core.Divisions;
using MessagePack;

namespace BusinessShark.Core.CityClasses
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class City
    {
        public City(string name, int width, int height)
        {
            Name = name;
            Map = new CityMap(width, height);
        }

        [SerializationConstructor]
        public City(string name, CityMap map)
        {
            Name = name;
            Map = map;
        }

        public CityMap Map { get; set; }
        public string Name { get; set; }

        public int Population
        {
            get
            {
                // Calculate total Population from the Grid of CityMap
                int population = 0;
                for (int i = 0; i < Map.Grid.GetLength(0); i++) // Rows
                {
                    for (int j = 0; j < Map.Grid.GetLength(1); j++) // Columns
                    {
                        population += Map.Grid[i, j].Population;
                    }
                }
                return population;
            }
        }

        public int Happiness { get; set; } = 0;
        public int WealthLevel { get; set; } = 0;
        public int LandPrice { get; set; } = 0;
        public int LandTax { get; set; } = 0;

        public List<Factory> Factories { get; set; } = new();
        public List<Warehouse> Warehouses { get; set; } = new();
        public List<ResourceExtractor> Sources { get; set; } = new();
    }
}
