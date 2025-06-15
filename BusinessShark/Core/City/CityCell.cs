using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessShark.Core.Item;

namespace BusinessShark.Core.City
{
    internal class CityCell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int LandCost { get; set; }
        public int RentCost { get; set; }
        public int Population { get; set; }
        public int Wealth { get; set; }

        public Enums.ResourceType Resource { get; set; }

        public override string ToString()
        {
            return $"({X},{Y}) | Land: {LandCost}, Rent: {RentCost}, Pop: {Population}, Wealth: {Wealth}, Res: {Resource}";
        }
    }
}
