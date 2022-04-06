using Microsoft.VisualStudio.TestTools.UnitTesting;

using Catan.Model.Context;

namespace Catan.Model.Test
{
    [TestClass]
    public class PlaceHolderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //placeholder test
            Goods goods = new Goods();
            Assert.IsNotNull(goods);

        }
    }
}