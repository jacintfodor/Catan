using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Catan.Model.Test
{
    [TestClass]
    public class TownTest
    {
        [TestMethod]
        [DataRow(PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player2)]
        [DataRow(PlayerEnum.Player3)]
        public void NoPlayerAdded(PlayerEnum player)
        {
            Town community = new Town(player);
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var states = new List<ICatanGameState> { state1, state2, state3, state4, state5, state6, state7, state8, state9 };

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, player);
            Assert.AreEqual(community.Type, CommunityEnum.Town);
            Assert.IsFalse(community.IsUpgradeable);
            Assert.IsFalse(community.IsBuildableCommunity);

            for (var index = 0; index < states.Count; index++)
                Assert.IsFalse(community.IsBuildableByPlayer(states[index], player));
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player2)]
        [DataRow(PlayerEnum.Player3)]
        public void OnePlayerAdded(PlayerEnum player)
        {
            Town community = new Town(player);
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var states = new List<ICatanGameState> { state1, state2, state3, state4, state5, state6, state7, state8, state9 };

            community.AddPotentionalBuilder(player);

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, player);
            Assert.AreEqual(community.Type, CommunityEnum.Town);
            Assert.IsFalse(community.IsUpgradeable);
            Assert.IsFalse(community.IsBuildableCommunity);

            for (var index = 0; index < states.Count; index++)
                Assert.IsFalse(community.IsBuildableByPlayer(states[index], player));
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player2)]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player2, PlayerEnum.Player3)]
        [DataRow(PlayerEnum.Player3, PlayerEnum.Player1)]
        [DataRow(PlayerEnum.Player3, PlayerEnum.Player2)]
        public void MorePlayerAdded(PlayerEnum player, PlayerEnum player2)
        {
            Town community = new Town(player);
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var states = new List<ICatanGameState> { state1, state2, state3, state4, state5, state6, state7, state8, state9 };

            community.AddPotentionalBuilder(player);
            community.AddPotentionalBuilder(player2);

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, player);
            Assert.AreEqual(community.Type, CommunityEnum.Town);
            Assert.IsFalse(community.IsUpgradeable);
            Assert.IsFalse(community.IsBuildableCommunity);

            for (var index = 0; index < states.Count; index++)
            {
                Assert.IsFalse(community.IsBuildableByPlayer(states[index], player));
                Assert.IsFalse(community.IsBuildableByPlayer(states[index], player2));
            }
        }

        [TestMethod]
        [DataRow(PlayerEnum.Player1, PlayerEnum.Player2, PlayerEnum.Player3)]
        public void AllPlayerAdded(PlayerEnum player, PlayerEnum player2, PlayerEnum player3)
        {
            Town community = new Town(player);
            ICatanGameState state1 = new EarlySettlementBuildingState(0), state2 = new EarlyRoadBuildingState(0), state3 = new EarlyRollingState(), state4 = new MainState(), state5 = new RoadBuildingState(), state6 = new RogueMovingState(), state7 = new RollingState(), state8 = new SettlementBuildingState(), state9 = new SettlementUpgradingState();
            var states = new List<ICatanGameState> { state1, state2, state3, state4, state5, state6, state7, state8, state9 };

            community.AddPotentionalBuilder(player);
            community.AddPotentionalBuilder(player2);
            community.AddPotentionalBuilder(player3);

            Assert.IsNotNull(community);
            Assert.AreEqual(community.Owner, player);
            Assert.AreEqual(community.Type, CommunityEnum.Town);
            Assert.IsFalse(community.IsUpgradeable);
            Assert.IsFalse(community.IsBuildableCommunity);

            for (var index = 0; index < states.Count; index++)
            {
                Assert.IsFalse(community.IsBuildableByPlayer(states[index], player));
                Assert.IsFalse(community.IsBuildableByPlayer(states[index], player2));
                Assert.IsFalse(community.IsBuildableByPlayer(states[index], player3));
            }
        }
    }
}
