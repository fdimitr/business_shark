using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;
using MessagePack;
using System.Text;
using System.Threading.Tasks;

namespace BusinessShark.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal class ResourceDeposit(
        ItemDefinition definition,
        Location location
        ) 
    {
        // this will have to be redone in the future
        public ItemDefinition ResourceDefinition = definition;
        public int ResourceQuality = 0;
        public int ResourceCapasity = 0;
        public string Name;
    }
}
