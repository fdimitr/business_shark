using System.Drawing;

namespace BusinessShark.Core
{
    internal abstract class Division(int divisionId, Point location)
    {
        public int DivisionId { get; } = divisionId;
        public Point Location { get; } = location;

        public abstract void StartCalculation();
        public abstract void CompleteCalculation();
    }
}
