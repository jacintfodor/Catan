using Catan.Model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Catan.Model.Test.Board.Components.Hex
{
    [TestClass]
    public class HexTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Model.Board.Components.Hex.Hex CreateHex(ResourceEnum rsc, int row, int col, int number)
        {
            return new Model.Board.Components.Hex.Hex(
                rsc,
                row,
                col,
                number);
        }

        [TestMethod]
        [DataRow(ResourceEnum.Ore, 2, 2, 4)]
        [DataRow(ResourceEnum.Desert, 3, 5, 12)]
        [DataRow(ResourceEnum.Wood, 1, 8, 8)]
        public void TestMethod1(ResourceEnum rsc, int row, int col, int num)
        {
            // Arrange
            var hex = this.CreateHex(rsc, row, col, num);

            // Act


            // Assert
            Assert.AreEqual(hex.Resource, rsc);
            Assert.AreEqual(hex.Row, row);
            Assert.AreEqual(hex.Col, col);
            Assert.AreEqual(hex.Value, num);
            this.mockRepository.VerifyAll();
        }
    }
}
