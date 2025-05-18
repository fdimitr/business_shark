using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessShark.Core
{
    internal class Market
    {
        public List<City> Cities = new();

        public void Calculate()
        {
            foreach (var city in Cities)
            {
                foreach (var factory in city.Factories)
                {
                    factory.Production();
                }
            }
        }
    }
}
