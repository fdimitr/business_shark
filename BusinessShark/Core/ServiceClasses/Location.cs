using System.Drawing;
using MessagePack;

namespace BusinessShark.Core.ServiceClasses
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Location
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Location() { }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point ToSystemPoint() => new Point(X, Y);
    }
}
