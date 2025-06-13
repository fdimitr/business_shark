namespace BusinessShark.Core.City
{
    public enum ResourceType
    {
        None,
        Forest,
        Agriculture
    }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int LandCost { get; set; }
        public int RentCost { get; set; }
        public int Population { get; set; }
        public int Wealth { get; set; }

        public ResourceType Resource { get; set; }

        public override string ToString()
        {
            return $"({X},{Y}) | Land: {LandCost}, Rent: {RentCost}, Pop: {Population}, Wealth: {Wealth}, Res: {Resource}";
        }
    }

    public class CityMap
    {
        public int Width { get; }
        public int Height { get; }
        public Cell[,] Grid { get; }

        public CityMap(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new Cell[width, height];
            GenerateMap();
        }

        private void GenerateMap()
        {
            int centerX = Width / 2;
            int centerY = Height / 2;
            int maxDistance = Math.Max(centerX, centerY);

            Random rand = new Random();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int dx = Math.Abs(x - centerX);
                    int dy = Math.Abs(y - centerY);
                    double distanceFactor = 1.0 - (double)(dx + dy) / (2.0 * maxDistance); // 1.0 в центре, 0.0 на краях

                    var cell = new Cell
                    {
                        X = x,
                        Y = y,
                        LandCost = (int)(1000 * distanceFactor),
                        RentCost = (int)(500 * distanceFactor),
                        Population = (int)(1000 * distanceFactor),
                        Wealth = (int)(10000 * distanceFactor),
                        Resource = GenerateResource(x, y, distanceFactor, rand)
                    };

                    Grid[x, y] = cell;
                }
            }
        }

        private ResourceType GenerateResource(int x, int y, double distanceFactor, Random rand)
        {
            // Чем дальше от центра, тем больше шанс на наличие ресурсов
            if (distanceFactor < 0.4)
            {
                int chance = rand.Next(100);
                if (chance < 30) return ResourceType.Forest;
                if (chance < 60) return ResourceType.Agriculture;
            }

            return ResourceType.None;
        }

        public void PrintMap()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write($"{Grid[x, y].LandCost,4} ");
                }
                Console.WriteLine();
            }
        }

        public void PrintDetailedMap()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.WriteLine(Grid[x, y]);
                }
            }
        }
    }

}
