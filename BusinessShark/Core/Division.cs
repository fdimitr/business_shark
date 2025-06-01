using BusinessShark.Core.ServiceClasses;
using MessagePack;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal abstract class Division(int divisionId, string name, Location location)
    {
        public int DivisionId { get; } = divisionId;
        public string Name { get; set; } = name;
        public string Description { get; set; }
        public Location Location { get; set; } = location;
        public float RentalCost { get; set; }

        public abstract void StartCalculation();
        public abstract void CompleteCalculation();
    }
}
