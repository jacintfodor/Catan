using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Catan.Model.Test
{
    [TestClass]
    public class BuildableCommunityTest
    {
        [TestMethod]
        [DataRow(PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player2)]
        [DataRow(PlayerEnum.Player3)]
        public void NoPlayerAdded(PlayerEnum player)
        {
            BuildableCommunity community = new BuildableCommunity();
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var earlyStates = new List<ICatanGameState> { state1, state2, state3 };
            var notEarlyStates = new List<ICatanGameState> { state4, state5, state6, state7, state8, state9 };

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, PlayerEnum.NotPlayer);
            Assert.AreEqual(community.Type, CommunityEnum.BuildableCommunity);
            Assert.IsFalse(community.IsUpgradeable);

            for (var index = 0; index < earlyStates.Count; index++)
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player));

            for (var index = 0; index < notEarlyStates.Count; index++)
                Assert.IsFalse(community.IsBuildableByPlayer(notEarlyStates[index], player));
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player2)]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player3, PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player3, PlayerEnum.Player2)]
        public void OnePlayerAdded(PlayerEnum player, PlayerEnum player2)
        {
            //Arrange
            BuildableCommunity community = new BuildableCommunity();
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var earlyStates = new List<ICatanGameState> { state1, state2, state3 };
            var notEarlyStates = new List<ICatanGameState> { state4, state5, state6, state7, state8, state9 };
            //Act
            community.AddPotentionalBuilder(player);
            //Assert
            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, PlayerEnum.NotPlayer);
            Assert.AreEqual(community.Type, CommunityEnum.BuildableCommunity);
            Assert.IsFalse(community.IsUpgradeable);

            for (var index = 0; index < earlyStates.Count; index++)
            {
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player));
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player2));
            }
            for (var index = 0; index < notEarlyStates.Count; index++)
            {
                Assert.IsTrue(community.IsBuildableByPlayer(notEarlyStates[index], player));
                Assert.IsFalse(community.IsBuildableByPlayer(notEarlyStates[index], player2));
            }
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player2, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player3, PlayerEnum.Player2)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player1, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player3, PlayerEnum.Player1)]
        public void MorePlayerAdded(PlayerEnum player, PlayerEnum player2, PlayerEnum player3)
        {
            BuildableCommunity community = new BuildableCommunity();
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var earlyStates = new List<ICatanGameState> { state1, state2, state3 };
            var notEarlyStates = new List<ICatanGameState> { state4, state5, state6, state7, state8, state9 };
            
            community.AddPotentionalBuilder(player);
            community.AddPotentionalBuilder(player2);

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, PlayerEnum.NotPlayer);
            Assert.AreEqual(community.Type, CommunityEnum.BuildableCommunity);
            Assert.IsFalse(community.IsUpgradeable);

            for (var index = 0; index < earlyStates.Count; index++) { 
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player));
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player2));
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player3));
            }
            for (var index = 0; index < notEarlyStates.Count; index++)
            {
                Assert.IsTrue(community.IsBuildableByPlayer(notEarlyStates[index], player));
                Assert.IsTrue(community.IsBuildableByPlayer(notEarlyStates[index], player2));
                Assert.IsFalse(community.IsBuildableByPlayer(notEarlyStates[index], player3));
            }
        }
        
        [TestMethod]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player1, PlayerEnum.Player2)]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player1, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player2, PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player2, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player3, PlayerEnum.Player3, PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player3, PlayerEnum.Player3, PlayerEnum.Player2)]
        public void SamePlayerAdded(PlayerEnum player, PlayerEnum player2, PlayerEnum player3)
        {
            BuildableCommunity community = new BuildableCommunity();
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var earlyStates = new List<ICatanGameState> { state1, state2, state3 };
            var notEarlyStates = new List<ICatanGameState> { state4, state5, state6, state7, state8, state9 };

            community.AddPotentionalBuilder(player);
            community.AddPotentionalBuilder(player2);

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, PlayerEnum.NotPlayer);
            Assert.AreEqual(community.Type, CommunityEnum.BuildableCommunity);
            Assert.IsFalse(community.IsUpgradeable);

            for (var index = 0; index < earlyStates.Count; index++)
            {
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player));
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player2));
                Assert.IsTrue(community.IsBuildableByPlayer(earlyStates[index], player3));
            }
            for (var index = 0; index < notEarlyStates.Count; index++)
            {
                Assert.IsTrue(community.IsBuildableByPlayer(notEarlyStates[index], player));
                Assert.IsTrue(community.IsBuildableByPlayer(notEarlyStates[index], player2));
                Assert.IsFalse(community.IsBuildableByPlayer(notEarlyStates[index], player3));
            }
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player2, PlayerEnum.Player3)]
        public void AllPlayerAdded(PlayerEnum player, PlayerEnum player2, PlayerEnum player3)
        {
            BuildableCommunity community = new BuildableCommunity();
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var states = new List<ICatanGameState> { state1, state2, state3, state4, state5, state6, state7, state8, state9 };

            community.AddPotentionalBuilder(player);
            community.AddPotentionalBuilder(player2);
            community.AddPotentionalBuilder(player3);

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, PlayerEnum.NotPlayer);
            Assert.AreEqual(community.Type, CommunityEnum.BuildableCommunity);
            Assert.IsFalse(community.IsUpgradeable);

            for (var index = 0; index < states.Count; index++)
            {
                Assert.IsTrue(community.IsBuildableByPlayer(states[index], player));
                Assert.IsTrue(community.IsBuildableByPlayer(states[index], player2));
                Assert.IsTrue(community.IsBuildableByPlayer(states[index], player3));
            }
        }
    }
}