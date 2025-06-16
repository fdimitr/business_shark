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
                        indicators?.Add(new CityCell.SellIndicator(attractiveness, this ));
                    }
                    else
                    {
                        cell.SellInfo[kvp.Key] =
                            [new CityCell.SellIndicator(attractiveness, this)];
                    }
                }
            }
        }

        public override void CompleteCalculation()
        {
            throw new NotImplementedException();
        }
    }
}
