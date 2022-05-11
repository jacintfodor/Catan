using Catan.Model.Board.Components;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Catan.Model.Test.Board.Components.Vertex
{
    [TestClass]
    public class VertexTests
    {
        private MockRepository mockRepository;
        private Mock<ICatanGameState> mockState;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            mockState = this.mockRepository.Create<ICatanGameState>();
        }

        private Model.Board.Components.Vertex.Vertex CreateVertex(ICommunity c = null)
        {
            return new Model.Board.Components.Vertex.Vertex(
                0,
                0,
                c);
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player2)]
        public void AddPotentialBuilder_StateUnderTest_ExpectedBehavior(PlayerEnum potentialPlayer, PlayerEnum invalidPlayer)
        {
            // Arrange
            ICatanGameState state = this.mockState.Object;
           
            IVertex vertex = this.CreateVertex();
            IVertex vertexSettlement = this.CreateVertex(new Settlement(potentialPlayer));

            // Act
            vertex.AddPotentialBuilder(
                potentialPlayer);
            vertexSettlement.AddPotentialBuilder(
                potentialPlayer);

            // Assert
            Assert.IsTrue(vertex.IsBuildableByPlayer(state, potentialPlayer));
            Assert.IsFalse(vertex.IsBuildableByPlayer(state, invalidPlayer));
            Assert.IsFalse(vertexSettlement.IsBuildableByPlayer(state, potentialPlayer));
            Assert.IsFalse(vertexSettlement.IsBuildableByPlayer(state, invalidPlayer));
            this.mockRepository.VerifyAll();
        }


        [TestMethod]
        public void IsBuildableByPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState state = this.mockState.Object;
            PlayerEnum player = default(PlayerEnum);
            PlayerEnum invalidPlayer = default(PlayerEnum) + 1;

            var vertex = this.CreateVertex();
            var vertexSettlement = this.CreateVertex();

            vertexSettlement.AddPotentialBuilder(player);
            vertexSettlement.BuildSettlement(state, player);

            vertex.AddPotentialBuilder(player);
            // Act
            var resultValid = vertex.IsBuildableByPlayer(
                state,
                player);
            var resultInvalid = vertex.IsBuildableByPlayer(
                    state,
                    invalidPlayer);
            var resultInvalidOnwer = vertexSettlement.IsBuildableByPlayer(
                state,
                player);
            var resultInvalidNonOwner = vertexSettlement.IsBuildableByPlayer(
                    state,
                    invalidPlayer);

            // Assert
            Assert.IsTrue(resultValid);
            Assert.IsFalse(resultInvalid);
            Assert.IsFalse(resultInvalidOnwer);
            Assert.IsFalse(resultInvalidNonOwner);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void BuildSettlement_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState state = this.mockState.Object;
            PlayerEnum player = default(PlayerEnum);
            PlayerEnum invalidPlayer = default(PlayerEnum) + 1;

            var vertex = this.CreateVertex();
            vertex.AddPotentialBuilder(
               player);

            // Act
            vertex.BuildSettlement(
                state,
                player);

            // Assert
            Assert.IsTrue(vertex.Type is CommunityEnum.Settlement);
            Assert.ThrowsException<InvalidOperationException>(() => vertex.BuildSettlement(state, invalidPlayer));
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void UpgradeToTown_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState state = this.mockState.Object;
            PlayerEnum player = default(PlayerEnum);

            var vertex = this.CreateVertex();
            vertex.AddPotentialBuilder(
               player);
            vertex.BuildSettlement(state, player);

            // Act
            vertex.UpgradeToTown();

            // Assert
            Assert.IsTrue(vertex.Type is CommunityEnum.Town);
            Assert.ThrowsException<InvalidOperationException>(() => vertex.UpgradeToTown());
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void SetNotBuildableCommunity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            IVertex vertex = this.CreateVertex();

            // Act
            vertex.SetNotBuildableCommunity();

            // Assert
            Assert.IsTrue(vertex.Type is CommunityEnum.NotBuildableCommunity);

            this.mockRepository.VerifyAll();
        }
    }
}
