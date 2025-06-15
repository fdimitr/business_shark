using BusinessShark.Core.ServiceClasses;

namespace BusinessShark.Core.Divisions
{
    internal class Store(int divisionId, string name, Location location) : DeliveryDivision(divisionId, name, location)
    {
        public Workers Workers { get; set; }

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
