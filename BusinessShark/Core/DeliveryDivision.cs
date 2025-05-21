using System.Drawing;
using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal abstract class DeliveryDivision(int divisionId, Point location) : Division(divisionId, location)
    {
        public Dictionary<Enums.ItemType, Item.Item> WarehouseInput = new();
        public Dictionary<Enums.ItemType, Item.Item> WarehouseOutput = new();

        public List<Routes> Routes { get; set; } = new();

        public void AcceptRequestedItems()
        {
        }
    }
}
