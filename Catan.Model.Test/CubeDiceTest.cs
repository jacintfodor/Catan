using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catan.Model.Context;
using System.IO;
using Catan.Model.Enums;
namespace Catan.Model.Test
{
    [TestClass]
    public class CubeDiceTest
    {
        [TestMethod]
        public void RollTest()
        {
            CubeDice dice = new CubeDice(155);
            Assert.AreEqual(1, dice.RolledValue);
            int sum = 0;
            int x = 100000;
            for (int i = 0; i < x; i++)
            {
                dice.roll();
                sum += dice.RolledValue;
                Assert.IsTrue(1 <= dice.RolledValue && dice.RolledValue <= 6);
            }
            float sum2 = sum;
            float f = sum2 / x;
            float tolerance = 0.02f;
            // 0.01 el is mindíg lefutott de a békesség kedvéért legyen 0.02
            float expectedValue = 3.5f;
            Assert.IsTrue(expectedValue - tolerance < f);
            Assert.IsTrue(f < expectedValue + tolerance);

        }
    }
}
