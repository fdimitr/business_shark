using BusinessShark.Core.CityClasses;
using BusinessShark.Core.ServiceClasses;
using MessagePack;

namespace BusinessShark.Core.Divisions
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class Store(int divisionId, string name, Location location, List<CityCell> tradeArea) : DeliveryDivision(divisionId, name, location)
    {
        public float RecognitionLevel { get; set; } = 0f; // 0.0 - 1.0, 1.0 - max recognition

        public Workers Workers { get; set; } = new Workers();
        public List<CityCell> TradeArea { get; set; } = tradeArea;

        public override void StartCalculation()
        {
            foreach (var cell in TradeArea)
            {
                foreach (var kvp in WarehouseOutput)
                {
                    var item = kvp.Value;
                    var attractiveness = item.CalculateAttractiveness(this);

                    if (cell.SellInfo.TryGetValue(kvp.Key, out List<CityCell.SellIndicator>? indicators))
                    {
                        indicators?.Add(new CityCell.SellIndicator(attractiveness, item.Quantity, this));
                    }
                    else
                    {
                        cell.SellInfo[kvp.Key] =
                            [new CityCell.SellIndicator(attractiveness, item.Quantity, this)];
                    }
                }
            }
        }

        public override void CompleteCalculation()
        {
            foreach (var cell in TradeArea)
            {
                foreach(var item in WarehouseOutput)
                {
                    if (item.Value.Quantity == 0)
                        continue; // Skip items with zero quantity

                    if (cell.SellInfo.TryGetValue(item.Key, out var value) && value != null)
                    {
                        var indicator = value.FirstOrDefault(si => si.Store == this);
                        if (indicator != null)
                        {
                            item.Value.Quantity = item.Value.Quantity <= indicator.CountOfSell
                                ? 0
                                : item.Value.Quantity - indicator.CountOfSell;
                        }
                    }
                }
            }
        }

        public void PutUpForSale()
        {
            foreach(var item in WarehouseInput)
            {
                WarehouseOutput.TryGetValue(item.Key, out var existingItem);
                if(existingItem == null)
                    {
                    WarehouseOutput[item.Key] = (Items.Item)item.Value.Clone();
                }
                else
                {
                    existingItem.Quality = CalculateWarehouseQuality(existingItem.Quantity, existingItem.Quality, item.Value.Quantity, item.Value.Quality);
                    existingItem.Quantity += item.Value.Quantity;
                }
                WarehouseInput[item.Key].Quantity = 0;
            }
            
        }
    }
}
