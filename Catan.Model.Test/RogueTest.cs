using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catan.Model.Context;


namespace Catan.Model.Test
{
    [TestClass]
    public class RogueTest
    {
        [TestMethod]
        public void Move()
        {
            Rogue.Instance.Move(0, 0);

            Assert.AreEqual(0, Rogue.Instance.Row);
            Assert.AreEqual(0, Rogue.Instance.Col);

            Rogue.Instance.Move(4, 1);

            Assert.AreEqual(4, Rogue.Instance.Row);
            Assert.AreEqual(1, Rogue.Instance.Col);

            Rogue.Instance.Move(3, 5);

            Assert.AreEqual(3, Rogue.Instance.Row);
            Assert.AreEqual(5, Rogue.Instance.Col);

        }

    }

}
