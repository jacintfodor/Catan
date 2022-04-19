using Microsoft.VisualStudio.TestTools.UnitTesting;

using Catan.Model.Context;
using System.Collections.Generic;
using System.IO;
using Catan.Model.Enums;

namespace Catan.Model.Test
{
    [TestClass]
    public class GoodsTest
    {
        [TestMethod]
        public void ResourceEnumConstructor()
        {
            ResourceEnum e = ResourceEnum.Crop;
            Goods goods1 = new Goods(e);

            Assert.IsNotNull(goods1);

            Assert.AreEqual(1, goods1.Crop);
            Assert.AreEqual(0, goods1.Ore);
            Assert.AreEqual(0, goods1.Wood);
            Assert.AreEqual(0, goods1.Brick);
            Assert.AreEqual(0, goods1.Wool);

            Assert.IsTrue(goods1.Valid);
        }

        [TestMethod]
        public void EmptyConstructor()
        {
            Goods goods1 = new Goods();

            Assert.IsNotNull(goods1);

            Assert.AreEqual(0, goods1.Crop);
            Assert.AreEqual(0, goods1.Ore);
            Assert.AreEqual(0, goods1.Wood);
            Assert.AreEqual(0, goods1.Brick);
            Assert.AreEqual(0, goods1.Wool);

            Assert.IsTrue(goods1.Valid);
        }

        [TestMethod]
        public void ConstructorWithList()
        {
            List<int> list1 = new List<int>() { 0, 1, 2, 3, 4 };

            Goods goods1 = new Goods(list1);

            Assert.IsNotNull(goods1);

            Assert.AreEqual(0, goods1.Crop);
            Assert.AreEqual(1, goods1.Ore);
            Assert.AreEqual(2, goods1.Wood);
            Assert.AreEqual(3, goods1.Brick);
            Assert.AreEqual(4, goods1.Wool);

            Assert.IsTrue(goods1.Valid);
        }

        [TestMethod]
        public void ConstructorWithWrongList()
        {
            List<int> list1 = new List<int>() { -1, 1, 2, 3, 4 };

            Goods goods1 = new Goods(list1);

            Assert.IsNotNull(goods1);

            Assert.AreEqual(-1, goods1.Crop);
            Assert.AreEqual(1, goods1.Ore);
            Assert.AreEqual(2, goods1.Wood);
            Assert.AreEqual(3, goods1.Brick);
            Assert.AreEqual(4, goods1.Wool);

            Assert.IsFalse(goods1.Valid);
        }

        [TestMethod]
        public void OperationPlus()
        {
            List<int> list1 = new List<int>() { 2, 2, 2, 2, 2 };
            List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };

            Goods goods1 = new Goods(list1);
            Goods goods2 = new Goods(list2);
            goods1 = goods1 + goods2;

            Assert.AreEqual(3, goods1.Crop);
            Assert.AreEqual(4, goods1.Ore);
            Assert.AreEqual(5, goods1.Wood);
            Assert.AreEqual(6, goods1.Brick);
            Assert.AreEqual(7, goods1.Wool);

            Assert.IsTrue(goods1.Valid);
        }

        [TestMethod]
        public void OperationMinus()
        {
            List<int> list1 = new List<int>() { 2, 2, 2, 2, 2 };
            List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };

            Goods goods1 = new Goods(list1);
            Goods goods2 = new Goods(list2);
            goods1 = goods1 - goods2;

            Assert.AreEqual(1, goods1.Crop);
            Assert.AreEqual(0, goods1.Ore);
            Assert.AreEqual(-1, goods1.Wood);
            Assert.AreEqual(-2, goods1.Brick);
            Assert.AreEqual(-3, goods1.Wool);

            Assert.IsFalse(goods1.Valid);

            goods1 = goods1 + goods2;

            Assert.AreEqual(2, goods1.Crop);
            Assert.AreEqual(2, goods1.Ore);
            Assert.AreEqual(2, goods1.Wood);
            Assert.AreEqual(2, goods1.Brick);
            Assert.AreEqual(2, goods1.Wool);

            Assert.IsTrue(goods1.Valid);
        }

        [TestMethod]
        public void OperationMultiplication()
        {
            List<int> list1 = new List<int>() { 1, 2, 3, 4, 5 };
            Goods goods1 = new Goods(list1);
            goods1 = goods1 * 2;

            Assert.AreEqual(2, goods1.Crop);
            Assert.AreEqual(4, goods1.Ore);
            Assert.AreEqual(6, goods1.Wood);
            Assert.AreEqual(8, goods1.Brick);
            Assert.AreEqual(10, goods1.Wool);

            Assert.IsTrue(goods1.Valid);

            goods1 = goods1 * -1;

            Assert.AreEqual(-2, goods1.Crop);
            Assert.AreEqual(-4, goods1.Ore);
            Assert.AreEqual(-6, goods1.Wood);
            Assert.AreEqual(-8, goods1.Brick);
            Assert.AreEqual(-10, goods1.Wool);

            Assert.IsFalse(goods1.Valid);

            goods1 = goods1 * 0;

            Assert.AreEqual(0, goods1.Crop);
            Assert.AreEqual(0, goods1.Ore);
            Assert.AreEqual(0, goods1.Wood);
            Assert.AreEqual(0, goods1.Brick);
            Assert.AreEqual(0, goods1.Wool);

            Assert.IsTrue(goods1.Valid);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "mismatching list count")]
        public void ConstructorListWithWrongLength()
        {
            List<int> wrongList = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Goods goods = new Goods(wrongList);
        }
    }
}