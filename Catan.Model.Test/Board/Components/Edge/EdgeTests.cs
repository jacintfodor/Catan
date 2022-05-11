using Catan.Model.Board.Components.Edge;
using Catan.Model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Catan.Model.Test.Board.Components.Edge
{
    [TestClass]
    public class EdgeTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

        }

        private Model.Board.Components.Edge.Edge CreateEdge()
        {
            return new Model.Board.Components.Edge.Edge(
                0,
                0);
        }

        [TestMethod]
        public void AddPotentialBuilder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(PlayerEnum);
            IEdge edge = this.CreateEdge();
            IEdge edgeRoad = this.CreateEdge();

            edgeRoad.AddPotentialBuilder(
                player);
            edgeRoad.Build(player);
            // Act
            edge.AddPotentialBuilder(
                player);
            edgeRoad.AddPotentialBuilder(
                player);

            // Assert
            Assert.IsTrue(edge.IsBuildableByPlayer(player));
            Assert.IsFalse(edgeRoad.IsBuildableByPlayer(player));
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void IsBuildableByPlayer_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(PlayerEnum);
            PlayerEnum invalidPlayer = default(PlayerEnum) + 1;

            IEdge edgeRoad = this.CreateEdge();
            IEdge edge = this.CreateEdge();

            edge.AddPotentialBuilder(player);
            edgeRoad.AddPotentialBuilder(player);
            edgeRoad.Build(player);


            // Act
            var resultTrue = edge.IsBuildableByPlayer(
                player);
            var resultFalse = edge.IsBuildableByPlayer(
                invalidPlayer);
            var resultOwner = edgeRoad.IsBuildableByPlayer(
                player);
            var resultNonOwner = edgeRoad.IsBuildableByPlayer(
                invalidPlayer);

            // Assert
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsFalse(resultNonOwner);
            Assert.IsFalse(resultOwner);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(PlayerEnum);
            PlayerEnum invalidPlayer = default(PlayerEnum) + 1;

            IEdge edge = this.CreateEdge();

            edge.AddPotentialBuilder(player);

            // Act
            edge.Build(
                player);

            // Assert
            Assert.IsTrue(edge.Owner == player);
            Assert.ThrowsException<InvalidOperationException>(() => edge.Build(player));
            Assert.ThrowsException<InvalidOperationException>(() => edge.Build(invalidPlayer));
            this.mockRepository.VerifyAll();
        }
    }
}
