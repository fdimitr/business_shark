using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessShark.Core.Item;

namespace BusinessShark.Core.City
{
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
