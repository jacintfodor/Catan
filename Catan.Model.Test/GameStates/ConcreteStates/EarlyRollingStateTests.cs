using Catan.Model.GameStates.ConcreteStates;
using Moq;
using System;
using Xunit;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    public class EarlyRollingStateTests
    {
        private MockRepository mockRepository;



        public EarlyRollingStateTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private EarlyRollingState CreateEarlyRollingState()
        {
            return new EarlyRollingState();
        }

        [Fact]
        public void RollDices_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var earlyRollingState = this.CreateEarlyRollingState();
            ICatanContext context = null;

            // Act
            earlyRollingState.RollDices(
                context);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
