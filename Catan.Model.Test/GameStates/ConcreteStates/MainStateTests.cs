using Catan.Model.Context;
using Catan.Model.Context.Players;
using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class MainStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;
        private Mock<ICatanGameState> mockState;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockContext = mockRepository.Create<ICatanContext>();
            this.mockState = mockRepository.Create<ICatanGameState>();

        }

        private MainState CreateMainState()
        {
            return new MainState();
        }

        [TestMethod]
        public void EndTurn_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            IMainState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.Winner).Returns(NotPlayer.Instance);
            this.mockContext.Setup(m => m.NextPlayer()).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            
        
            // Act
            mainState.EndTurn(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void ExchangeWithBank_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            IMainState mainState = this.CreateMainState();
            ICatanContext context = new CatanContext(this.mockState.Object);
            ResourceEnum from = default(ResourceEnum);
            ResourceEnum to = default(ResourceEnum) + 1;



            //this.mockContext.Setup(m => m.CurrentPlayer.ReduceResources(new Goods(from) * 3)).Verifiable();
            //this.mockContext.Setup(m => m.CurrentPlayer.AddResource(new Goods(to))).Verifiable();
            //this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();


            // Act
            mainState.ExchangeWithBank(
                context,
                from,
                to);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void PurchaseBonusCard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            IMainState mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.CurrentPlayer.PurchaseBonusCard(Constants.BonusCardCost)).Verifiable();
            this.mockContext.Setup(m => m.CurrentPlayer.ReduceResources(Constants.BonusCardCost)).Verifiable();
            this.mockContext.Setup(m => m.LargestArmyHolder.ProcessOwner(context.CurrentPlayer)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();

            // Act
            mainState.PurchaseBonusCard(
                context);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void StartRoadBuilding_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            /*this.mockContext.Setup(m => m.init());
            this.mockContext.Setup(m => m.Events.OnRoadBuildingStarted(new List<EdgeDTO>()));
            this.mockContext.Setup(m => m.SetContext(new RoadBuildingState()));*/

            // Act
            var o = new CatanContext(mainState);
            o?.init();
            mainState.StartRoadBuilding(
                o);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void StartSettlementBuilding_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            // Act
            var o = new CatanContext(mainState);
            o?.init();
            mainState.StartSettlementBuilding(
                o);

            // Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void StartSettlementUpgrading_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mainState = this.CreateMainState();
            ICatanContext context = this.mockContext.Object;

            // Act
            var o = new CatanContext(mainState);
            o?.init();
            mainState.StartSettlementUpgrading(
                o);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
