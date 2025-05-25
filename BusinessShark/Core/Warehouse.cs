using System.Drawing;
using System.Text.Json.Serialization;
using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;
using MessagePack;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Warehouse : DeliveryDivision
    {
        public int Volume { get; }

        public Dictionary<Enums.ItemType, Item.Item> WarehouseItems = new();

        [JsonConstructor]
        public Warehouse(int divisionId, string name, Location location, int volume) : base(divisionId, name, location)
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
