using System.Drawing;
using BusinessShark.Core;
using BusinessShark.Core.Item;

namespace BusinessSharTests.Core
{
    [TestFixture]
    public class WarehouseTests
    {
        private const float Tolerant = 0.0001f;

        private DeliveryDivision _fromDivision;
        private DeliveryDivision _toDivision;
        private ItemDefinition _itemDef;
        private Item _fromItem;
        private Item _toItem;

        [SetUp]
        public void SetUp()
        {
            _itemDef = new ItemDefinition((int)Enums.ItemType.Wood, "Wood", 1, 1, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f,
                0.1f);
            _fromDivision = new Warehouse(1, new Point(0, 0), Int32.MaxValue);
            _toDivision = new Warehouse(2, new Point(1, 1), Int32.MaxValue);

            _fromItem = new Item(_itemDef, quality: 10, quantity: 100);
            _toItem = new Item(_itemDef, quality: 5, quantity: 50);

            _fromDivision.WarehouseOutput[Enums.ItemType.Wood] = _fromItem;
            _toDivision.WarehouseInput[Enums.ItemType.Wood] = _toItem;
        }

        [Test]
        public void StartTransferItems_TransfersCorrectQuantityAndQuality()
        {
            // Arrange
            var route = new Routes(_fromDivision, _toDivision, Enums.ItemType.Wood, 30);
            _fromDivision.Routes.Add(route);

            // Act
            _fromDivision.StartTransferItems();

            // Assert
            var targetItem = _toDivision.WarehouseInput[Enums.ItemType.Wood];
            Assert.That(targetItem.ProcessingQuantity, Is.EqualTo(30));
            Assert.That(_fromDivision.WarehouseOutput[Enums.ItemType.Wood].Quantity, Is.EqualTo(70));
            Assert.That(targetItem.ProcessingQuality, Is.EqualTo(10));
        }

        [Test]
        public void StartTransferItems_TransfersAllIfNotEnough()
        {
            // Arrange
            var route = new Routes(_fromDivision, _toDivision, Enums.ItemType.Wood, 200);
            _fromDivision.Routes.Add(route);

            // Act
            _fromDivision.StartTransferItems();

            // Assert
            var targetItem = _toDivision.WarehouseInput[Enums.ItemType.Wood];
            Assert.That(targetItem.ProcessingQuantity, Is.EqualTo(100));
            Assert.That(_fromDivision.WarehouseOutput[Enums.ItemType.Wood].Quantity, Is.EqualTo(0));
        }

        [Test]
        public void CompleteTransferItems_MovesProcessingToQuantityAndResets()
        {
            // Arrange
            var route = new Routes(_fromDivision, _toDivision, Enums.ItemType.Wood, 30);
            _fromDivision.Routes.Add(route);
            _fromDivision.StartTransferItems();

            var targetItem = _toDivision.WarehouseInput[Enums.ItemType.Wood];
            int prevQuantity = targetItem.Quantity;

            // Act
            _fromDivision.CompleteTransferItems();

            // Assert
            Assert.That(targetItem.Quantity, Is.EqualTo(prevQuantity + 30));
            Assert.That(targetItem.Quality, Is.EqualTo(6.875).Within(Tolerant));
            Assert.That(targetItem.ProcessingQuantity, Is.EqualTo(0));
            Assert.That(targetItem.ProcessingQuality, Is.EqualTo(0));
        }
    }
}
