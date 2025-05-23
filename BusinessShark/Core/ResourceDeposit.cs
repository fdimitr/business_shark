using BusinessShark.Core.Item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessShark.Core
{
    internal class ResourceDeposit(
        ItemDefinition definition,
        Point location
        ) 
    {
        // this will have to be redone in the future
        public ItemDefinition ResourceDefinition = definition;
        public int ResourceQuality = 0;
        public int ResourceRichness = 0;
        string name;
    }
}
