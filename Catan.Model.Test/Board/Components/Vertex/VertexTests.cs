using Catan.Model.Board.Components;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
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
        public void AddPotentialBuilder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState s = this.mockState.Object;
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            PlayerEnum invalidPlayer = default(global::Catan.Model.Enums.PlayerEnum) + 1;

            IVertex vertex = this.CreateVertex();
            IVertex vertexSettlement = this.CreateVertex(new Settlement(player));

            // Act
            vertex.AddPotentialBuilder(
                player);
            vertexSettlement.AddPotentialBuilder(
                player);

            // Assert
            Assert.IsTrue(vertex.IsBuildableByPlayer(s, player));
            Assert.IsFalse(vertex.IsBuildableByPlayer(s, invalidPlayer));
            Assert.IsFalse(vertexSettlement.IsBuildableByPlayer(s, player));
            Assert.IsFalse(vertexSettlement.IsBuildableByPlayer(s, invalidPlayer));
            this.mockRepository.VerifyAll();
        }


        [TestMethod]
        public void IsBuildableByPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            ICatanGameState state = this.mockState.Object;
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            PlayerEnum invalidPlayer = default(global::Catan.Model.Enums.PlayerEnum) + 1;

            var vertex = this.CreateVertex();
            var vertexCommunity = this.CreateVertex(new Settlement(player));

            vertex.AddPotentialBuilder(player);
            // Act
            var resultValid = vertex.IsBuildableByPlayer(
                state,
                player);
            var resultInvalid = vertex.IsBuildableByPlayer(
                    state,
                    invalidPlayer);
            var resultInvalidOnwer = vertexCommunity.IsBuildableByPlayer(
                state,
                player);
            var resultInvalidNonOwner = vertexCommunity.IsBuildableByPlayer(
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
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            PlayerEnum invalidPlayer = default(global::Catan.Model.Enums.PlayerEnum) + 1;

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
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);

            var vertex = this.CreateVertex(new Settlement(player));


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
            ICatanGameState state = this.mockState.Object;

            var vertex = this.CreateVertex();

            // Act
            vertex.SetNotBuildableCommunity();

            // Assert
            Assert.IsTrue(vertex.Type is CommunityEnum.NotBuildableCommunity);

            this.mockRepository.VerifyAll();
        }
    }
}
