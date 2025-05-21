using System.Drawing;
using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Warehouse(int divisionId, Point location, int volume) : Division(divisionId, location)
    {
        public int Volume { get; } = volume;

        public Dictionary<Enums.ItemType, Item.Item> WarehouseItems = new();
        public override void StartCalculation()
        {
            throw new NotImplementedException();
        }

        public override void CompleteCalculation()
        {
            throw new NotImplementedException();
        }
    }
}
