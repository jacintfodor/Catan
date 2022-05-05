using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Catan.Model.GameStates.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class EarlyRollingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockContext = this.mockRepository.Create<ICatanContext>();
        }

        private EarlyRollingState CreateEarlyRollingState()
        {
            return new EarlyRollingState();
        }

        [TestMethod]
        public void RollDices_CallOnce_DoesNotChangeState()
        {
            // Arrange
            ICatanGameState state = this.CreateEarlyRollingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.FirstDice.roll()).Verifiable();
            this.mockContext.Setup(m => m.SecondDice.roll()).Verifiable();

            this.mockContext.Setup(m => m.CurrentPlayer.ID).Returns(PlayerEnum.Player1);
            this.mockContext.Setup(m => m.RolledSum).Returns(12);

            this.mockContext.Setup(m => m.NextPlayer()).Verifiable();

            this.mockContext.Setup(m => m.Events.OnPlayer(context)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnDiceThrown(context)).Verifiable();



            // Act
            var o = state as IRollable;
            o?.RollDices(context);

            // Assert
            Assert.IsNotNull(o);
            
            this.mockContext.Verify(m => m.FirstDice.roll(), Times.Once());
            this.mockContext.Verify(m => m.SecondDice.roll(), Times.Once());
            this.mockContext.Verify(m => m.SetContext(It.IsAny<ICatanGameState>()), Times.Never);
            
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void RollDices_CallThrice_ChangesState()
        {
            // Arrange
            ICatanGameState state = this.CreateEarlyRollingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.FirstDice.roll()).Verifiable();
            this.mockContext.Setup(m => m.SecondDice.roll()).Verifiable();

            this.mockContext.SetupSequence(m => m.CurrentPlayer.ID)
                .Returns(PlayerEnum.Player1)
                .Returns(PlayerEnum.Player2)
                .Returns(PlayerEnum.Player3);
            this.mockContext.SetupSequence(m => m.RolledSum)
                .Returns(12)
                .Returns(8)
                .Returns(7);

            this.mockContext.Setup(m => m.NextPlayer()).Verifiable();

            this.mockContext.Setup(m => m.Events.OnPlayer(context)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnDiceThrown(context)).Verifiable();



            // Act
            var o = state as IRollable;
            o?.RollDices(context);
            o?.RollDices(context);
            o?.RollDices(context);

            // Assert
            Assert.IsNotNull(o);

            this.mockContext.Verify(m => m.FirstDice.roll(), Times.Once());
            this.mockContext.Verify(m => m.SecondDice.roll(), Times.Once());
            this.mockRepository.VerifyAll();
        }
    }
}
