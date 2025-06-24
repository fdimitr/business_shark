using BusinessShark.Core.ServiceClasses;
using MessagePack;

namespace BusinessShark.Core.Divisions
{
    [MessagePackObject(keyAsPropertyName: true)]
    internal abstract class Division
    {
        protected Division(int divisionId, string name, Location location, Enums.SizeType sizeType)
        {
            DivisionId = divisionId;
            Name = name;
            Location = location;
            SizeType = sizeType;
            Size = new DivisionSize(sizeType);
            PlaceDivisionOnMap();
        }

        public int DivisionId { get; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Location Location { get; set; }
        public float RentalCost { get; set; }

        public Enums.SizeType SizeType { get; }
        public DivisionSize Size { get; }

        public abstract void StartCalculation();
        public abstract void CompleteCalculation();

        private void PlaceDivisionOnMap()
        {
            var map = Location.City.Map;
            int startX = Location.Position.X;
            int startY = Location.Position.Y;
            int width = Size.Width;
            int height = Size.Height;

            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    var cell = map.Grid[x, y];
                    cell.SetDivision(DivisionId, true);
                }
            }
        }

        public void DestroyDivision()
        {
            var map = Location.City.Map;
            int startX = Location.Position.X;
            int startY = Location.Position.Y;
            int width = Size.Width;
            int height = Size.Height;
            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    var cell = map.Grid[x, y];
                    cell.DestroyDivision();
                }
            }
        }
    }
}
