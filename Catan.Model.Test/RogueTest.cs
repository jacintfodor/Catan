using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catan.Model.Context;

namespace Catan.Model.Test
{
    [TestClass]
    public class RogueTest
    {
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(3, 3)]
        [DataRow(4, 1)]
        [DataRow(3, 5)]
        public void MoveTest(int x, int y)
        {
            Rogue.Instance.Move(x, y);
            Assert.AreEqual(x, Rogue.Instance.Row);
            Assert.AreEqual(y, Rogue.Instance.Col);
        }
    }
}
