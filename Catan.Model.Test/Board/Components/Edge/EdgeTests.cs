using Catan.Model.Board.Components.Edge;
using Catan.Model.Context;
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

        private Model.Board.Components.Edge.Edge CreateEdge(IRoad road = null)
        {
            return new Model.Board.Components.Edge.Edge(
                0,
                0,
                road);
        }

        [TestMethod]
        public void AddPotentialBuilderWithoutRoad_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            IEdge edge = this.CreateEdge();

            // Act
            edge.AddPotentialBuilder(
                player);

            // Assert
            Assert.IsTrue(edge.IsBuildableByPlayer(player));
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void AddPotentialBuilderWithRoad_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            IEdge edge = this.CreateEdge(new BuiltRoad(player));

            // Act
            edge.AddPotentialBuilder(
                player);

            // Assert
            Assert.IsFalse(edge.IsBuildableByPlayer(player));
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void IsBuildableByPlayerWithoutRoad_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);
            PlayerEnum invalidPlayer = default(global::Catan.Model.Enums.PlayerEnum) + 1;
            IEdge edge = this.CreateEdge();
            edge.AddPotentialBuilder(player);

            // Act
            var resultTrue = edge.IsBuildableByPlayer(
                player);
            var resultFalse = edge.IsBuildableByPlayer(
                invalidPlayer);

            // Assert
            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void IsBuildableByPlayerWithRoad_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum potentialPlayer = default(global::Catan.Model.Enums.PlayerEnum);
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum) + 1;

            IEdge edge = this.CreateEdge(new BuiltRoad(potentialPlayer));

            edge.AddPotentialBuilder(potentialPlayer);

            // Act
            var resultOwner = edge.IsBuildableByPlayer(
                potentialPlayer);
            var resultNonOwner = edge.IsBuildableByPlayer(
                player);

            // Assert
            Assert.IsFalse(resultNonOwner);
            Assert.IsFalse(resultOwner);
            this.mockRepository.VerifyAll();
        }
        
        [TestMethod]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);

            IEdge edge = this.CreateEdge();

            edge.AddPotentialBuilder(player);

            // Act
            edge.Build(
                player);

            // Assert
            Assert.IsTrue(edge.Owner == player);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void BuildWithoutPermission_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);

            IEdge edge = this.CreateEdge();

            // Act
            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => edge.Build(player));
            
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void BuildOnRoad_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            PlayerEnum player = default(global::Catan.Model.Enums.PlayerEnum);

            IEdge edge = this.CreateEdge();

            edge.AddPotentialBuilder(player);

            // Act
            edge.Build(
                player);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => edge.Build(player));
            this.mockRepository.VerifyAll();
        }
    }
}
