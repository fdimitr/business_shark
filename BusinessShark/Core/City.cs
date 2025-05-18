namespace BusinessShark.Core
{
    internal class City(string name)
    {
        public string Name { get; set; } = name;
        public int Population { get; set; } = 0;
        public int Happiness { get; set; } = 0;
        public int WealthLevel { get; set; } = 0;
        public int LandPrice { get; set; } = 0;
        public int LandTax { get; set; } = 0;

        public List<Factory> Factories = new();
    }
}
