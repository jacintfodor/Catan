using Catan.Model.Board;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Board.Components.Hex;
using Catan.Model.Board.Components.Edge;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catan.Model.Test.Board
{
    [TestClass]
    public class CatanBoardTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanGameState> mockState;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockState = this.mockRepository.Create<ICatanGameState>();

        }

        private CatanBoard CreateCatanBoard()
        {
            return new CatanBoard();
        }

        [TestMethod]
        public void GetEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int col = 2;
            // Act
            var result = catanBoard.GetEdge(
                row,
                col);

            // Assert
            Assert.IsTrue(result.Row == 2);
            Assert.IsTrue(result.Col == 2);
            Assert.IsTrue(result.Owner == PlayerEnum.NotPlayer);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetVerticesOfHex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int col = 2;

            // Act
            var result = catanBoard.GetVerticesOfHex(
                row,
                col);

            // Assert
            Assert.IsTrue(result.Count == 6);
            Assert.IsTrue(result[0] is Vertex);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetNeighborVerticesOfVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int cornerRow = 0;
            int col = 2;

            // Act
            var result = catanBoard.GetNeighborVerticesOfVertex(
                row,
                col);

            var resultCorner = catanBoard.GetNeighborVerticesOfVertex(
                cornerRow,
                col);

            // Assert
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0] is Vertex);
            Assert.IsTrue(resultCorner.Count == 2);
            Assert.IsTrue(resultCorner[0] is Vertex);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetNeighborEdgesOfVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 4;
            int cornerRow = 0;
            int col = 2;

            // Act
            var result = catanBoard.GetNeighborEdgesOfVertex(
                row,
                col);

            var resultCorner = catanBoard.GetNeighborEdgesOfVertex(
                cornerRow,
                col);

            // Assert
            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[0] is Edge);
            Assert.IsTrue(resultCorner.Count == 2);
            Assert.IsTrue(resultCorner[0] is Edge);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetNeighbourVerticesOfEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int col = 2;

            // Act
            var result = catanBoard.GetNeighbourVerticesOfEdge(
                row,
                col);

            // Assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0] is Vertex);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetEdgesofEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 4;
            int col = 4;

            int colTwo = 1;
            int rowTwo = 1;

            int colThree = 1;
            int rowThree = 2;

            // Act
            var resultTwoNeightbour = catanBoard.GetEdgesofEdge(
                rowTwo,
                colTwo);

            var resultThreeNeightbour = catanBoard.GetEdgesofEdge(
                rowThree,
                colThree);

            var resultFourNeightbour = catanBoard.GetEdgesofEdge(
                row,
                col);

            // Assert
            Assert.IsTrue(resultTwoNeightbour.Count == 2);
            Assert.IsTrue(resultTwoNeightbour[0] is Edge);
            Assert.IsTrue(resultThreeNeightbour.Count == 3);
            Assert.IsTrue(resultThreeNeightbour[0] is Edge);
            Assert.IsTrue(resultFourNeightbour.Count == 4);
            Assert.IsTrue(resultFourNeightbour[0] is Edge);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetHexesEnumerable_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();

            // Act
            var result = catanBoard.GetHexesEnumerable();

            // Assert
            Assert.IsTrue(result is IEnumerable<IHex>);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetVerticesEnumerable_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();

            // Act
            var result = catanBoard.GetVerticesEnumerable();

            // Assert
            Assert.IsTrue(result is IEnumerable<IVertex>);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GetEdgesEnumerable_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();

            // Act
            var result = catanBoard.GetEdgesEnumerable();

            // Assert
            Assert.IsTrue(result is IEnumerable<IEdge>);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void BuildRoad_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int col = 2;
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).AddPotentialBuilder(player);

            // Act
            catanBoard.BuildRoad(
                row,
                col,
                player);

            // Assert
            Assert.IsTrue(catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).Owner == PlayerEnum.Player1);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void BuildSettlement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int col = 2;
            ICatanGameState state = this.mockState.Object;
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).AddPotentialBuilder(player);

            // Act
            catanBoard.BuildSettlement(
                row,
                col,
                state,
                player);

            // Assert
            Assert.IsTrue(catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).Owner == PlayerEnum.Player1);
            Assert.IsTrue(catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).Type == CommunityEnum.Settlement);

            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void UpgradeSettlement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int col = 2;
            ICatanGameState state = this.mockState.Object;
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).AddPotentialBuilder(player);

            catanBoard.BuildSettlement(
                row,
                col,
                state,
                player);

            // Act
            catanBoard.UpgradeSettlement(
                row,
                col);

            // Assert
            Assert.IsTrue(catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).Owner == PlayerEnum.Player1);
            Assert.IsTrue(catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).Type == CommunityEnum.Town);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void CalculateLongestRoadFromEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            int row = 2;
            int col = 2;
            PlayerEnum id = default(global::Catan.Model.Enums.PlayerEnum);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 3).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 4).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 5).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 1 && elem.Col == 2).AddPotentialBuilder(id);

            catanBoard.BuildRoad(row,col, id);
            catanBoard.BuildRoad(row,col+1, id);
            catanBoard.BuildRoad(row,col+2, id);
            catanBoard.BuildRoad(row,col+3, id);
            catanBoard.BuildRoad(row-1,col, id);


            // Act
            var result = catanBoard.CalculateLongestRoadFromEdge(
                row,
                col,
                id);

            // Assert
            Assert.IsTrue(result == 5);
            this.mockRepository.VerifyAll();
        }
        
        [TestMethod]
        public void GetBuildableRoadsByPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            PlayerEnum id = default(global::Catan.Model.Enums.PlayerEnum);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 3).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 4).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 2 && elem.Col == 5).AddPotentialBuilder(id);
            catanBoard.GetEdgesEnumerable().First(elem => elem.Row == 1 && elem.Col == 2).AddPotentialBuilder(id);

            // Act
            var result = catanBoard.GetBuildableRoadsByPlayer(
                id);

            // Assert
            Assert.IsTrue(result.Count == 5);
            this.mockRepository.VerifyAll();
        }
        [TestMethod]
        public void GetBuildableSettlementsByPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            ICatanGameState state = this.mockState.Object;
            PlayerEnum id = default(global::Catan.Model.Enums.PlayerEnum);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).AddPotentialBuilder(id);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 3).AddPotentialBuilder(id);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 4).AddPotentialBuilder(id);
           
            // Act
            var result = catanBoard.GetBuildableSettlementsByPlayer(
                state,
                id);

            // Assert
            Assert.IsTrue(result.Count == 3);
            this.mockRepository.VerifyAll();
        }
        
        [TestMethod]
        public void GetUpgradeableSettlementsByPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanBoard catanBoard = this.CreateCatanBoard();
            ICatanGameState state = this.mockState.Object;
            PlayerEnum id = default(global::Catan.Model.Enums.PlayerEnum);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 2).AddPotentialBuilder(id);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 2 && elem.Col == 4).AddPotentialBuilder(id);
            catanBoard.GetVerticesEnumerable().First(elem => elem.Row == 3 && elem.Col == 3).AddPotentialBuilder(id);
            catanBoard.BuildSettlement(2, 2, state,id);
            catanBoard.BuildSettlement(3, 3, state,id);
            catanBoard.BuildSettlement(2, 4, state,id);
            // Act
            var result = catanBoard.GetUpgradeableSettlementsByPlayer(
                id);

            // Assert
            Assert.IsTrue(result.Count == 3);
            this.mockRepository.VerifyAll();
        }
    }
}
