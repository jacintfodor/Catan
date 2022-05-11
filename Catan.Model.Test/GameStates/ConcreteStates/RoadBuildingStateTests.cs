//RoadBuildingStateTests
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.Test.GameStates.ConcreteStates
{
    [TestClass]
    public class RoadBuildingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;
        private Mock<ICatanGameState> mockState;


        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockContext = this.mockRepository.Create<ICatanContext>();
            this.mockState = this.mockRepository.Create<ICatanGameState>();
        }

        private RoadBuildingState CreateRoadBuildingState()
        {
            return new RoadBuildingState();
        }

        [TestMethod]
        [DataRow(4, 4)]
        //[DataRow(4, 4)]
        //[DataRow(5, 5)]
        //[DataRow(1, 2)]
        //[DataRow(3, 2)]
        public void BuildRoad_StateUnderTest_ExpectedBehavior(int r, int c)
        {
            // Arrange
            IRoadBuildable state = this.CreateRoadBuildingState();
            ICatanContext context = this.mockContext.Object;
            int row = r;
            int col = c;
            this.mockContext.Setup(m => m.CurrentPlayer.ID).Returns(PlayerEnum.Player1);
            this.mockContext.Setup(m => m.Board.BuildRoad(row, col, PlayerEnum.Player1)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnRoadBuilt(context, row, col, PlayerEnum.Player1)).Verifiable();

            context.CurrentPlayer.LengthOfLongestRoad = context.Board.CalculateLongestRoadFromEdge(row, col, context.CurrentPlayer.ID);

            this.mockContext.Setup(m => m.LongestRoadOwner.ProcessOwner(context.CurrentPlayer)).Verifiable();

            this.mockContext.Setup(m => m.CurrentPlayer.BuildRoad()).Verifiable();
            this.mockContext.Setup(m => m.CurrentPlayer.ReduceResources(Constants.RoadCost)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<MainState>())).Verifiable();
            // Act
            var o = state as IRoadBuildable;
            o?.BuildRoad(context, row, col);

            // Assert
            this.mockContext.Verify(m => m.SetContext(It.IsAny<MainState>()));
            //Assert.AreEqual(context.Board.GetEdge(row, col).Owner, PlayerEnum.Player1);
            //Assert.IsTrue(context.Board.GetEdge(row, col).Owner == PlayerEnum.Player1);// context.CurrentPlayer.ID);
            //Assert.IsTrue(context.Board.GetEdge(row, col).Owner == PlayerEnum.Player2);// context.CurrentPlayer.ID);
            //Assert.IsTrue(context.Board.GetEdge(row, col).Owner == PlayerEnum.Player3);// context.CurrentPlayer.ID);


            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Cancel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICancellable roadBuildingState = this.CreateRoadBuildingState();
            ICatanContext context = this.mockContext.Object;

            this.mockContext.Setup(m => m.Events.OnCancelled()).Verifiable();
            this.mockContext.Setup(m => m.SetContext(It.IsAny<MainState>())).Verifiable();
            // Act
            roadBuildingState.Cancel(context);

            // Assert
            this.mockRepository.VerifyAll();
        }
    }
}
