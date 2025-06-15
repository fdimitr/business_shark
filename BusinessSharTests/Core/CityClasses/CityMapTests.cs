using BusinessShark.Core.CityClasses;

namespace BusinessSharkTests.Core.CityClasses
{
    [TestFixture]
    public class CityMapTests
    {
        private CityMap _map;

        [SetUp]
        public void Setup()
        {
            _map = new CityMap(3, 3);

            // We fill the population according to the matrix:
            // 10 20 30
            // 40 50 60
            // 70 80 90
            int[,] populations = new[,]
            {
                {10, 20, 30},
                {40, 50, 60},
                {70, 80, 90}
            };

            for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                _map.Grid[x, y].Population = populations[y, x];  // y строки, x столбцы
        }

        [Test]
        public void TestPopulationAroundCenter_IncludesDiagonals()
        {
            // Center (1,1)
            int result = _map.GetPopulationAtDistance(1, 1);

            // Sum of all neighbors except the center:
            // 10 + 20 + 30 + 40 + 60 + 70 + 80 + 90 = 400
            Assert.That(result, Is.EqualTo(400));
        }

        [Test]
        public void TestPopulationAroundCorner_IncludesDiagonals()
        {
            // Upper left corner (0,0)
            int result = _map.GetPopulationAtDistance(0, 0);

            // Neighbours (0,0): (0,1)=40, (1,0)=20, (1,1)=50
            // All at a distance of 1 or ~1.41
            int expected = 40 + 20 + 50;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestPopulationAroundEdge_IncludesDiagonals()
        {
            // Left side (0,1)
            int result = _map.GetPopulationAtDistance(0, 1);

            // Neighbours: (0,0)=10, (1,0)=20, (1,1)=50, (1,2)=80, (0,2)=70
            int expected = 10 + 20 + 50 + 80 + 70;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestPopulationAroundRectangle_2x1()
        {
            // Rectangle width 2, height 1, starts at (0,1)
            // Cells: (0,1)=40 and (1,1)=50

            int result = _map.GetPopulationAtDistance(0, 1, 2, height: 1);

            /*
                Neighbors for rectangle (0,1)-(1,1):
                - above: (0,0)=10, (1,0)=20
                - below: (0,2)=70, (1,2)=80
                - to the left of (0,1): (0,1) none, none outside
                - to the right of (1,1): (2,1)=60
                - diagonally: (2,0)=30, (2,2)=90

                Sum: 10 + 20 + 70 + 80 + 60 + 30 + 90 = 360
            */

            Assert.That(result, Is.EqualTo(360));
        }

        [Test]
        public void TestPopulationAroundRectangle_1x2()
        {
            // Rectangle width 1, height 2, starts at (1,0)
            // Cells: (1,0)=20 and (1,1)=50

            int result = _map.GetPopulationAtDistance(1, 0, 1, 2);

            /*
                Neighbors:
                - left: (0,0)=10, (0,1)=40
                - right: (2,0)=30, (2,1)=60
                - below: (1,2)=80
                - diagonally: (0,2)=70, (2,2)=90

                Sum: 10 + 40 + 30 + 60 + 80 + 70 + 90 = 380
            */

            Assert.That(result, Is.EqualTo(380));
        }

        [Test]
        public void TestPopulationAroundRectangle_2x2()
        {
            // 2x2 rectangle with top left corner at (0,0)
            // Cells: (0,0)=10, (1,0)=20, (0,1)=40, (1,1)=50

            int result = _map.GetPopulationAtDistance(0, 0, 2, 2);

            /*
                Neighbors (cells around 2x2):
                - top: none
                - bottom: (0,2)=70, (1,2)=80
                - left: none
                - right: (2,0)=30, (2,1)=60, (2,2)=90
                - diagonally bottom right: (2,2)=90 (already calculated)
                - diagonally bottom left: none

                Sum: 30 + 60 + 70 + 80 + 90 = 330
            */

            Assert.That(result, Is.EqualTo(330));
        }
    }
}
