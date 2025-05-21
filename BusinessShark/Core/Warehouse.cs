using System.Drawing;
using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal class Warehouse : DeliveryDivision
    {
        public int Volume { get; }

        public Dictionary<Enums.ItemType, Item.Item> WarehouseItems = new();

        public Warehouse(int divisionId, Point location, int volume) : base(divisionId, location)
        {
            Volume = volume;
            WarehouseOutput = WarehouseInput;
        }

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
