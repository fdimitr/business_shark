using System.Drawing;
using BusinessShark.Core.Item;

namespace BusinessShark.Core
{
    internal abstract class DeliveryDivision(int divisionId, Point location) : Division(divisionId, location)
    {
        public Dictionary<Enums.ItemType, Item.Item> WarehouseInput = new();  //to
        public Dictionary<Enums.ItemType, Item.Item> WarehouseOutput = new(); //from

        public List<Routes> Routes { get; set; } = new();

        public void StartTransferItems()
        {
            foreach (var route in Routes)
            {
                if(route.FromDivision.WarehouseOutput.TryGetValue(route.TransferringItemType, out var item))
                {
                    if(item ==  null || item.Quantity == 0)
                    {

                    }
                    else
                    {
                        if (item.Quantity >= route.TransferringCount)
                        {
                            route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity += route.TransferringCount;
                            // need to fix nest string
                            route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuality = route.FromDivision.WarehouseOutput[route.TransferringItemType].Quality; 

                            route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity -= route.TransferringCount;
                        }
                        else
                        {

                            route.ToDivision.WarehouseInput[route.TransferringItemType].ProcessingQuantity += route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity;

                            route.FromDivision.WarehouseOutput[route.TransferringItemType].Quantity = 0;
                        }
                    }
                }
                
            }
        }
    }
}
