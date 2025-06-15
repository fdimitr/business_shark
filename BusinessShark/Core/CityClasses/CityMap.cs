using BusinessShark.Core.Item;
using MessagePack;

namespace BusinessShark.Core.CityClasses
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class CityMap
    {
        public int Width { get; }
        public int Height { get; }
        public CityCell[,] Grid { get; }

        public CityMap(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new CityCell[width, height];
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

                    var cell = new CityCell
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

        private Enums.ResourceType GenerateResource(int x, int y, double distanceFactor, Random rand)
        {
            // Чем дальше от центра, тем больше шанс на наличие ресурсов
            if (distanceFactor < 0.4)
            {
                int chance = rand.Next(100);
                if (chance < 30) return Enums.ResourceType.Forest;
                if (chance < 60) return Enums.ResourceType.Agriculture;
            }

            return Enums.ResourceType.None;
        }

        public int GetPopulationAtDistance(int startX, int startY, int width = 1, int height = 1, int distance = 1)
        {
            double minDistance = 1; // Минимальное расстояние для учета
            double maxDistance = distance + 0.5; // Максимальное расстояние для учета

            HashSet<(int, int)> considered = new HashSet<(int, int)>();
            int totalPopulation = 0;

            int searchRadius = (int)Math.Ceiling(maxDistance);
            int minX = Math.Max(0, startX - searchRadius);
            int maxX = Math.Min(Width - 1, startX + width - 1 + searchRadius);
            int minY = Math.Max(0, startY - searchRadius);
            int maxY = Math.Min(Height - 1, startY + height - 1 + searchRadius);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (x >= startX && x < startX + width && y >= startY && y < startY + height)
                        continue;

                    int nearestX = Math.Max(startX, Math.Min(x, startX + width - 1));
                    int nearestY = Math.Max(startY, Math.Min(y, startY + height - 1));

                    double euclideanDistance = Math.Sqrt((x - nearestX) * (x - nearestX) + (y - nearestY) * (y - nearestY));

                    if (euclideanDistance >= minDistance && euclideanDistance <= maxDistance)
                    {
                        if (considered.Add((x, y)))
                        {
                            totalPopulation += Grid[x, y].Population;
                        }
                    }
                }
            }

            return totalPopulation;
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
