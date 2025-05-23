using System.Drawing;

namespace BusinessShark.Core
{
    internal abstract class Division(int divisionId, string name, Point location)
    {
        public string Name { get; } = name;
        public string Description { get; set; }

        public int DivisionId { get; } = divisionId;
        public Point Location { get; } = location;

        public abstract void StartCalculation();
        public abstract void CompleteCalculation();
    }
}
