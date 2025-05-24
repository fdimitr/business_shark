using System.Text.Json.Serialization;

namespace BusinessShark.Core
{
    [Serializable]
    [method: JsonConstructor]
    internal class City(string name)
    {
        public string Name { get; set; } = name;
        public int Population { get; set; } = 0;
        public int Happiness { get; set; } = 0;
        public int WealthLevel { get; set; } = 0;
        public int LandPrice { get; set; } = 0;
        public int LandTax { get; set; } = 0;

        public List<Factory> Factories { get; set; } = new();
        public List<Warehouse> Warehouses { get; set; } = new();
    }
}
