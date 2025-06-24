using System.Drawing;
using BusinessShark.Core.CityClasses;
using MessagePack;

namespace BusinessShark.Core.ServiceClasses
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Location(int x, int y, City city)
    {
        public int X { get; } = x;
        public int Y { get; } = y;

        public City City { get; } = city;

        public Point Position { get; } = new(x, y);
    }
}
