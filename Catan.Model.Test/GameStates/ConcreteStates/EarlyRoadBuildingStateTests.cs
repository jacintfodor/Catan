using Catan.Model.Board.Components.Vertex;
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
    public class EarlyRoadBuildingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockContext = this.mockRepository.Create<ICatanContext>();
        }

        private EarlyRoadBuildingState CreateEarlyRoadBuildingState(int n)
        {
            return new EarlyRoadBuildingState(n);
        }

        [TestMethod]
        [DataRow(0, PlayerEnum.Player1)]
        [DataRow(5, PlayerEnum.Player2)]
        [DataRow(6, PlayerEnum.Player3)]
        public void BuildRoad_StateUnderTest_ExpectedBehavior(int _turnCount, PlayerEnum expectedStarterPlayer)
        {
            // Arrange
            ICatanGameState state = this.CreateEarlyRoadBuildingState(_turnCount);
            ICatanContext context = this.mockContext.Object;
            int row = 0;
            int col = 0;
            this.mockContext.Setup(m => m.CurrentPlayer.ID).Returns(expectedStarterPlayer);
            this.mockContext.Setup(m => m.Board.BuildRoad(row, col, context.CurrentPlayer.ID)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID)).Verifiable();

            context.CurrentPlayer.LengthOfLongestRoad = context.Board.CalculateLongestRoadFromEdge(row, col, context.CurrentPlayer.ID);
            /** /
            this.mockContext.Setup(m => m.CurrentPlayer.LengthOfLongestRoad).Returns(3);
            this.mockContext.Setup(m => m.Board.CalculateLongestRoadFromEdge(row, col, context.CurrentPlayer.ID)).Returns(3);
            /**/
            this.mockContext.Setup(m => m.LongestRoadOwner.ProcessOwner(context.CurrentPlayer)).Verifiable();
            if (_turnCount == 6)
            {
                this.mockContext.Setup(m => m.DistributeResources(state)).Verifiable();
                this.mockContext.Setup(m => m.SetContext(It.IsAny<RollingState>()));
            }
            else
            {
                var list = new List<IVertex>() { new Vertex(row, col) };
                this.mockContext.Setup(m => m.Board.GetBuildableSettlementsByPlayer(state, expectedStarterPlayer))
                    .Returns(list);
                List<VertexDTO> listDTO = list.Select(x => Mapping.Mapper.Map<VertexDTO>(x)).ToList();

                this.mockContext.Setup(m => m.Events.OnSettlementBuildingStarted(listDTO)).Verifiable();
                this.mockContext.Setup(m => m.SetContext(It.IsAny<EarlySettlementBuildingState>()));
            }
            // Act
            var o = state as IRoadBuildable;
            o?.BuildRoad(context, row, col);

            // Assert
            if (_turnCount != 6)
                this.mockContext.Verify(m => m.SetContext(It.IsAny<EarlySettlementBuildingState>()), Times.Once);
            else
                this.mockContext.Verify(m => m.SetContext(It.IsAny<RollingState>()), Times.Once);
            this.mockRepository.VerifyAll();
        }
    }
}
