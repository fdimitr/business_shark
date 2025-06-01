using System.Drawing;
using BusinessShark.Core;
using BusinessShark.Core.Item;
using BusinessShark.Core.ServiceClasses;

namespace BusinessSharTests.Core
{
    [TestFixture]
    internal partial class FactoryTests
    {
        private const float Tolerance = 0.0001f;

        private static ItemDefinition CreateTestItemDefinition_With_BaseQuality(float baseProductionCount = 1.0f)
        {
            return new ItemDefinition(
                itemDefinitionId: Enums.ItemType.Bed,
                name: "TestProduct",
                volume: 1.0f,
                baseProductionCount: baseProductionCount,
                techImpactQuality: 1.0f,
                toolImpactQuality: 1.0f,
                workerImpactQuality: 1.0f,
                sourceImpactQuality: 1.0f,
                techImpactQuantity: 0.30f,
                toolImpactQuantity: 0.5f,
                workerImpactQuantity: 0.2f,
                baseProductionPrice:0.0f
            )
            {
                ProductionUnits =
                [
                    new ProductionUnit(
                        productDefinitionId: Enums.ItemType.Bed,
                        componentDefinitionId: Enums.ItemType.Wood,
                        productionQuantity: 2,
                        qualityImpact: 1.0f
                    ),

                    new ProductionUnit(
                        productDefinitionId: Enums.ItemType.Bed,
                        componentDefinitionId: Enums.ItemType.Leather,
                        productionQuantity: 1,
                        qualityImpact: 1.0f
                    )
                ]
            };
        }

        private static Factory CreateFactoryWithResources(ItemDefinition productDef, float techLevel = 1.0f, float toolTechLevel = 1.0f, float workerTechLevel = 1.0f)
        {
            var tools = new Tools { TechLevel = toolTechLevel, TotalQuantity = 1 };
            var workers = new Workers { TechLevel = workerTechLevel, TotalQuantity = 1 };
            var factory = new Factory(
                divisionId: 1,
                name: "TestFactory",
                productDefinition: productDef,
                techLevel: techLevel,
                toolPark: tools,
                workers: workers,
                location: new Location()
            )
            {
                WarehouseInput =
                {
                    // Add enough input resources
                    [Enums.ItemType.Wood] = new Item(productDef, quantity: 10,  quality: 1.0f),
                    [Enums.ItemType.Leather] = new Item(productDef, quantity: 10, quality: 1.0f)
                }
            };

            return factory;
        }

        [Test]
        public void StartCalculation_ProducesItem_WhenResourcesAvailable()
        {
            // Arrange
            var factory = CreateFactoryWithResources(CreateTestItemDefinition_With_BaseQuality());

            // Act
            factory.StartCalculation();

            // Assert
            factory.WarehouseOutput.TryGetValue(Enums.ItemType.Bed, out var item);
            Assert.That(item, Is.Not.Null);
            Assert.That(item.ProcessingQuantity, Is.EqualTo(1));
            Assert.That(item.ProcessingQuality, Is.EqualTo(5) );
        }

        [Test]
        public void StartCalculation_DoesNotProduce_WhenResourcesInsufficient()
        {
            // Arrange
            var productDef = CreateTestItemDefinition_With_BaseQuality();
            var tools = new Tools { TechLevel = 1.0f, TotalQuantity = 1 };
            var workers = new Workers { TechLevel = 1.0f, TotalQuantity = 1 };
            var factory = new Factory(
                divisionId: 1,
                name: "TestFactory",
                productDefinition: productDef,
                techLevel: 1.0f,
                toolPark: tools,
                workers: workers,
                location: new Location()
            )
            {
                WarehouseInput =
                {
                    // Not enough input
                    [Enums.ItemType.Wood] = new Item(productDef, quantity: 0, quality:1.0f),
                    [Enums.ItemType.Leather] = new Item(productDef, quantity: 2, quality:1.0f)
                }
            };

            // Act
            factory.StartCalculation();

            // Assert
            Assert.That(factory.WarehouseOutput, Is.Empty);
        }

        [Test]
        public void StartCalculation_DoesNotProduce_WhenResourcesAbsent()
        {
            // Arrange
            var productDef = CreateTestItemDefinition_With_BaseQuality();
            var tools = new Tools { TechLevel = 1.0f, TotalQuantity = 1 };
            var workers = new Workers { TechLevel = 1.0f, TotalQuantity = 1 };
            var factory = new Factory(
                divisionId: 1,
                name: "TestFactory",
                productDefinition: productDef,
                techLevel: 1.0f,
                toolPark: tools,
                workers: workers,
                location: new Location()
            );

            // Not enough input
            factory.WarehouseInput.Clear();

            // Act
            factory.StartCalculation();

            // Assert
            Assert.That(factory.WarehouseOutput, Is.Empty);
        }

        [Test]
        public void StartCalculation_CompletesProduction_In_Few_Cycles()
        {
            // Arrange
            var productDef = CreateTestItemDefinition_With_BaseQuality(baseProductionCount: 0.5f);
            var tools = new Tools { TechLevel = 1.0f, TotalQuantity = 1 };
            var workers = new Workers { TechLevel = 1.0f, TotalQuantity = 1 };
            var factory = new Factory(
                divisionId: 1,
                name: "TestFactory",
                productDefinition: productDef,
                techLevel: 1.0f,
                toolPark: tools,
                workers: workers,
                location: new Location()
            )
            {
                WarehouseInput =
                {
                    // Not enough input
                    [Enums.ItemType.Wood] = new Item(productDef, quantity: 10, quality:1.0f),
                    [Enums.ItemType.Leather] = new Item(productDef, quantity: 10, quality:1.0f)
                }
            };

            // Act
            factory.StartCalculation();
            factory.CompleteCalculation();
            factory.StartCalculation();
            factory.CompleteCalculation();

            // Assert
            factory.WarehouseOutput.TryGetValue(Enums.ItemType.Bed, out var item);
            Assert.That(item, Is.Not.Null);
            Assert.That(item.ProcessingQuantity, Is.EqualTo(0));
            Assert.That(item.ProcessingQuality, Is.EqualTo(0));
            Assert.That(item.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void StartCalculation_OverProduction_TwoCycles_WithoutChangesInItems()
        {
            // Arrange
            var productDef = CreateTestItemDefinition_With_BaseQuality(baseProductionCount: 0.5f);
            var tools = new Tools { TechLevel = 3.0f, TotalQuantity = 1 };
            var workers = new Workers { TechLevel = 3.0f, TotalQuantity = 1 };
            var factory = new Factory(
                divisionId: 1,
                name: "TestFactory",
                productDefinition: productDef,
                techLevel: 1.0f,
                toolPark: tools,
                workers: workers,
                location: new Location()
            )
            {
                WarehouseInput =
                {
                    // Not enough input
                    [Enums.ItemType.Wood] = new Item(productDef, quantity: 10, quality:1.0f),
                    [Enums.ItemType.Leather] = new Item(productDef, quantity: 10, quality:1.0f)
                }
            };

            // Act
            factory.StartCalculation();
            factory.CompleteCalculation();
            factory.StartCalculation();
            factory.CompleteCalculation();

            // Assert
            factory.WarehouseOutput.TryGetValue(Enums.ItemType.Bed, out var item);
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Quantity, Is.EqualTo(2));
            Assert.That(factory.ProgressProduction, Is.EqualTo(0.4).Within(Tolerance));
        }

        [Test]
        public void StartCalculation_OverProduction_TwoCycles_WithChangesInItems()
        {
            // Arrange
            var productDef = CreateTestItemDefinition_With_BaseQuality(baseProductionCount: 0.5f);
            var tools = new Tools { TechLevel = 3.0f, TotalQuantity = 1 };
            var workers = new Workers { TechLevel = 3.0f, TotalQuantity = 1 };
            var factory = new Factory(
                divisionId: 1,
                name: "TestFactory",
                productDefinition: productDef,
                techLevel: 1.0f,
                toolPark: tools,
                workers: workers,
                location: new Location()
            )
            {
                WarehouseInput =
                {
                    // Not enough input
                    [Enums.ItemType.Wood] = new Item(productDef, quantity: 10, quality:1.0f),
                    [Enums.ItemType.Leather] = new Item(productDef, quantity: 10, quality:1.0f)
                }
            };

            // Act
            factory.StartCalculation();
            factory.CompleteCalculation();

            var firstCycleQuality = factory.ProgressQuality;

            factory.WarehouseInput[Enums.ItemType.Wood].Quality = 4.0f;

            factory.StartCalculation();
            factory.CompleteCalculation();

            var secondCycleQuality = factory.ProgressQuality;

            // Assert
            factory.WarehouseOutput.TryGetValue(Enums.ItemType.Bed, out var item);
            Assert.That(item, Is.Not.Null);
            Assert.That(firstCycleQuality, Is.LessThan(secondCycleQuality));
            Assert.That(item.Quality, Is.EqualTo((firstCycleQuality + secondCycleQuality) /2).Within(Tolerance));
            Assert.That(factory.ProgressProduction, Is.EqualTo(0.4).Within(Tolerance));


        }
    }
}
