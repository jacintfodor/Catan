using Catan.Model.Context;
using Catan.Model.Context.Players;
using Catan.Model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;


namespace Catan.Model.Test.Context.Players
{
    [TestClass]
    public class PlayerTests
    {
        private MockRepository mockRepository;
        //        private Mock<ICatanContext> mockContext;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            //this.mockContext = this.mockRepository.Create<ICatanContext>();
        }

        private Player CreatePlayer(PlayerEnum name)
        {
            return new Player(name);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void BuildSettlement_StateUnderTest_ExpectedBehavior(int n)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);

            // Act
            for (int i = 0; i < n; i++)
                player.SpendSettlementCard();
            // Assert
            Assert.AreEqual(player.AvailableSettlementCardCount, 5 - n);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void BuildTown_StateUnderTest_ExpectedBehavior(int n)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);

            // Act
            for (int i = 0; i < n; i++)
                player.SpendTownCard();

            // Assert
            Assert.AreEqual(player.AvailableTownCardCount, 5 - n);
            Assert.AreEqual(player.AvailableSettlementCardCount, 5 + n);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void BuildRoad_StateUnderTest_ExpectedBehavior(int n)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);

            // Act
            for (int i = 0; i < n; i++)
                player.SpendRoadCards();
            // Assert

            Assert.AreEqual(player.AvailableRoadCardCount, 15 - n);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        public void CanBuildSettlement_StateUnderTest_ExpectedBehavior(int n)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);

            // Act
            for (int i = 0; i < n; i++)
                player.SpendSettlementCard();
            var result = player.CanBuildSettlement();

            // Assert
            if (n < 5)
                Assert.IsTrue(result);
            else
                Assert.IsFalse(result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        public void CanBuildTown_StateUnderTest_ExpectedBehavior(int n)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);

            // Act
            for (int i = 0; i < n; i++)
                player.SpendTownCard();
            var result = player.CanBuildTown();

            // Assert
            if (n < 5)
                Assert.IsTrue(result);
            else
                Assert.IsFalse(result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(6)]
        [DataRow(9)]
        [DataRow(14)]
        [DataRow(15)]
        [DataRow(20)]
        [DataRow(33)]
        public void CanBuildRoad_StateUnderTest_ExpectedBehavior(int n)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);

            // Act
            for (int i = 0; i < n; i++)
                player.SpendRoadCards();
            var result = player.CanBuildRoad();

            // Assert
            if (n < 15)
                Assert.IsTrue(result);
            else
                Assert.IsFalse(result);
            this.mockRepository.VerifyAll();
        }


        [TestMethod]
        [DataRow(1, 1, 1, 1, 1)]
        [DataRow(2, 1, 3, 3, 3)]
        [DataRow(5, -2, 0, 4, 0)]
        [DataRow(0, 0, 0, 0, 0)]

        public void AddResource_StateUnderTest_ExpectedBehavior(int Crop, int Ore, int Wood, int Brick, int Wool)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);
            List<int> list1 = new() { Crop, Ore, Wood, Brick, Wool };
            Goods resourcesToAdd = new Goods(list1);

            // Act
            player.AddResource(resourcesToAdd);

            // Assert
            Assert.AreEqual(player.AvailableResources.Crop, resourcesToAdd.Crop);
            Assert.AreEqual(player.AvailableResources.Ore, resourcesToAdd.Ore);
            Assert.AreEqual(player.AvailableResources.Wood, resourcesToAdd.Wood);
            Assert.AreEqual(player.AvailableResources.Brick, resourcesToAdd.Brick);
            Assert.AreEqual(player.AvailableResources.Wool, resourcesToAdd.Wool);

            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        [DataRow(1, 1, 1, 1, 1)]
        [DataRow(2, 1, 3, 3, 3)]
        [DataRow(5, -2, 0, 4, 0)]
        [DataRow(0, 0, 0, 0, 0)]

        public void ReduceResources_StateUnderTest_ExpectedBehavior(int Crop, int Ore, int Wood, int Brick, int Wool)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);
            List<int> list1 = new() { Crop, Ore, Wood, Brick, Wool };
            Goods resourcesToReduce = new Goods(list1);

            // Act
            player.ReduceResources(resourcesToReduce);

            // Assert
            Assert.AreEqual(player.AvailableResources.Crop, -resourcesToReduce.Crop);
            Assert.AreEqual(player.AvailableResources.Ore, -resourcesToReduce.Ore);
            Assert.AreEqual(player.AvailableResources.Wood, -resourcesToReduce.Wood);
            Assert.AreEqual(player.AvailableResources.Brick, -resourcesToReduce.Brick);
            Assert.AreEqual(player.AvailableResources.Wool, -resourcesToReduce.Wool);

            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, true)]
        [DataRow(2, 1, 3, 3, 3, true)]
        [DataRow(10, 10, 10, 10, 10, true)]
        [DataRow(5, -2, 0, 4, 0, false)]
        [DataRow(0, 0, 0, 0, 0, false)]
        public void CanAfford_StateUnderTest_ExpectedBehavior(int Crop, int Ore, int Wood, int Brick, int Wool, bool b)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);
            List<int> list1 = new() { Crop, Ore, Wood, Brick, Wool };
            Goods resourcesToAdd = new Goods(list1);
            Goods resourcesToSpend = Constants.BonusCardCost;

            // Act
            player.AddResource(resourcesToAdd);

            var result = player.CanAfford(resourcesToSpend);

            // Assert
            Assert.IsTrue(result == b);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void PurchaseBonusCard_StateUnderTest_ExpectedBehavior(int n)
        {
            // Arrange
            var player = this.CreatePlayer(PlayerEnum.Player1);
            List<int> list1 = new() { 10, 10, 10, 10, 10 };
            Goods resourcesToSpend = new Goods(list1);

            // Act
            for (int i = 0; i < n; i++)
                player.DrawBonusCard();

            // Assert
            Assert.IsTrue((player.KnightCardCount + player.ScoreCardCount) == n);
            this.mockRepository.VerifyAll();
        }
    }
}
