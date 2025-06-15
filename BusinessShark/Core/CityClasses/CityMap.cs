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

        public int GetPopulationAtDistance(int startX, int startY, int width = 1, int height = 1, int distance = 3)
        {
            HashSet<(int, int)> considered = new HashSet<(int, int)>();
            int totalPopulation = 0;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    // Вычисляем минимальное расстояние от (x, y) до прямоугольной области
                    int dx = 0;
                    if (x < startX) dx = startX - x;
                    else if (x >= startX + width) dx = x - (startX + width - 1);

                    int dy = 0;
                    if (y < startY) dy = startY - y;
                    else if (y >= startY + height) dy = y - (startY + height - 1);

                    int manhattanDistance = dx + dy;

                    if (manhattanDistance == distance)
                    {
                        // Учитываем только уникальные ячейки (на случай перекрытия)
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
