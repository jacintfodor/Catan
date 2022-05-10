using Catan.Model.Board.Components.Edge;
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
    public class EarlySettlementBuildingStateTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanContext> mockContext;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);
            this.mockContext = this.mockRepository.Create<ICatanContext>();
        }

        private EarlySettlementBuildingState CreateEarlySettlementBuildingState(int num)
        {
            return new EarlySettlementBuildingState(num);
        }

        [TestMethod]
        [DataRow(3, 4, PlayerEnum.Player1)]
        [DataRow(5, 6, PlayerEnum.Player2)]
        [DataRow(6, 6, PlayerEnum.Player2)]
        [DataRow(2, 5, PlayerEnum.Player3)]
        [DataRow(3, 4, PlayerEnum.Player3)]
        public void BuildSettleMent_StateUnderTest_ExpectedBehavior(int r, int c, PlayerEnum player)
        {
            // Arrange
            ICatanGameState state = this.CreateEarlySettlementBuildingState(0);
            ICatanContext context = this.mockContext.Object;
            int row = r;
            int col = c;

            this.mockContext.Setup(m => m.CurrentPlayer.BuildSettlement()).Verifiable();
            this.mockContext.Setup(m => m.Events.OnPlayerUpdated(context)).Verifiable();
            this.mockContext.Setup(m => m.Board.BuildSettlement(row, col, context.State, context.CurrentPlayer.ID)).Verifiable();
            this.mockContext.Setup(m => m.Events.OnSettlementBuilt(context, row, col, context.CurrentPlayer.ID)).Verifiable();

            var list = new List<IEdge>() { new Edge(row, col, new BuiltRoad(player)) };
            this.mockContext.Setup(m => m.Board.GetNeighborEdgesOfVertex(row, col)).Returns(list);
            List<EdgeDTO> listDTO = list.Select(x => Mapping.Mapper.Map<EdgeDTO>(x)).ToList();

            //this.mockContext.Setup(m => m.Events.OnRoadBuildingStarted(listDTO)).Verifiable();
            //this.mockContext.Setup(m => m.SetContext(It.IsAny<EarlyRoadBuildingState>(1))).Verifiable();
            context.Events.OnRoadBuildingStarted(listDTO);
            context.SetContext(new EarlyRoadBuildingState(1));

            // Act
            var o = state as ISettlementBuildable;
            o?.BuildSettleMent(context, row, col);

            // Assert
            Assert.IsTrue(listDTO[0].Row == row && listDTO[0].Col == col);
            Assert.IsTrue(listDTO[0].Owner == player);

            this.mockRepository.VerifyAll();
        }
    }
}
