using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessShark.Core.Item;
using BusinessShark.Core;

namespace BusinessSharTests.Core
{
    internal partial class FactoryTests
    {
        [Test]
        public void CalculateProductionQuality_ReturnsExpectedQuality_WithValidInputs()
        {
            // Arrange
            var productionUnits = new List<ProductionUnit>
            {
                new ProductionUnit(1, 1, 2, 0.2f),
                new ProductionUnit(1, 2, 3, 0.3f)
            };
            var productDefinition = new ItemDefinition(
                3, "TestProduct", 1, 1, 0.2f, 0.2f, 0.1f, 0, 0.1f, 0.1f, 0.1f)
            {
                ProductionUnits = productionUnits
            };

            var tools = new Tools { TechLevel = 2 };
            var workers = new Workers { TechLevel = 3 };
            var factory = new Factory(1, productDefinition, 4, tools, workers, new Point(0, 0));

            var qualityItems = new List<Factory.QualityItem>
            {
                new Factory.QualityItem(5, 0.2f),
                new Factory.QualityItem(7, 0.3f)
            };

            // Act
            var result = factory.CalculateProductionQuality(qualityItems);

            // Assert
            // result is = 5*0.2 + 7*0.3 + 4*0.2 + 2*0.2 + 3*0.1 = 1 + 2.1 + 0.8 + 0.4 + 0.3 = 4.6
            Assert.That(result, Is.EqualTo(4.6).Within(Tolerance));
        }


        [Test]
        public void CalculateProductionQuality_ReturnsExpectedQuality_WithValidInputs_With_Some_0_Impacts()
        {
            // Arrange
            var productionUnits = new List<ProductionUnit>
            {
                new ProductionUnit(1, 1, 2, 0.2f),
                new ProductionUnit(1, 2, 3, 0.3f)
            };
            var productDefinition = new ItemDefinition(
                3, "TestProduct", 1, 1, 0, 0, 0.1f, 0, 0.1f, 0.1f, 0.1f)
            {
                ProductionUnits = productionUnits
            };

            var tools = new Tools { TechLevel = 2 };
            var workers = new Workers { TechLevel = 3 };
            var factory = new Factory(1, productDefinition, 4, tools, workers, new Point(0, 0));

            var qualityItems = new List<Factory.QualityItem>
            {
                new Factory.QualityItem(5, 0.2f),
                new Factory.QualityItem(7, 0.3f)
            };

            // Act
            var result = factory.CalculateProductionQuality(qualityItems);

            // Assert
            // result is = 5*0.2 + 7*0.3 + 4*0 + 2*0 + 3*0.1 = 1 + 2.1 + 0 + 0 + 0.3 = 3.4
            Assert.That(result, Is.EqualTo(3.4).Within(Tolerance));
        }
    }
}
