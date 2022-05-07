using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catan.Model.Context;

namespace Catan.Model.Test
{
    [TestClass]
    public class CubeDiceTest
    {
        [TestMethod]
        public void RollTest()
        {
            //Arrange
            ICubeDice dice = new CubeDice(155);
            Assert.AreEqual(1, dice.RolledValue);
            float sum = 0;
            int x = 100000;
            float tolerance = 0.02f;
            float expectedValue = 3.5f;

            //Act
            for (int i = 0; i < x; i++)
            {
                dice.roll();
                sum += dice.RolledValue;
                Assert.IsTrue(1 <= dice.RolledValue && dice.RolledValue <= 6);
            }
            float f = sum / x;

            //Assert
            Assert.IsTrue(expectedValue - tolerance < f);
            Assert.IsTrue(f < expectedValue + tolerance);
        }
    }
}
