using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catan.Model.Context;
using System.IO;
using Catan.Model.Enums;
using Catan.Model.Board.Components;

namespace Catan.Model.Test
{
    [TestClass]
    public class CommunityTest
    {
        [TestMethod]
        public void BuildableCommunityTest()
        {
            BuildableCommunity buildableCommunity = new BuildableCommunity();
            
            Assert.AreEqual(PlayerEnum.NotPlayer, buildableCommunity.Owner);
            Assert.IsFalse(buildableCommunity.IsUpgradeable);
            Assert.IsTrue(buildableCommunity.IsBuildableCommunity);
            
            buildableCommunity.AddPotentionalBuilder(PlayerEnum.Player1);
            
            Assert.IsTrue(buildableCommunity.IsBuildableByPlayer(PlayerEnum.Player1));
            Assert.IsFalse(buildableCommunity.IsBuildableByPlayer(PlayerEnum.Player2));

            buildableCommunity.AddPotentionalBuilder(PlayerEnum.Player2);
            

            Assert.IsTrue(buildableCommunity.IsBuildableByPlayer(PlayerEnum.Player1));
            Assert.IsTrue(buildableCommunity.IsBuildableByPlayer(PlayerEnum.Player2));
            Assert.IsFalse(buildableCommunity.IsBuildableByPlayer(PlayerEnum.Player3));
            
            buildableCommunity.AddPotentionalBuilder(PlayerEnum.Player3);
            Assert.IsTrue(buildableCommunity.IsBuildableByPlayer(PlayerEnum.Player3));

        }
        [TestMethod]
        public void SettlementTest()
        {
            Settlement settlement = new Settlement(PlayerEnum.Player1);
            
            Assert.AreEqual(PlayerEnum.Player1, settlement.Owner);
            
            Assert.IsTrue(settlement.IsUpgradeable);
            Assert.IsFalse(settlement.IsBuildableCommunity);
            
            settlement.AddPotentionalBuilder(PlayerEnum.Player2);
            Assert.AreNotEqual(PlayerEnum.Player2, settlement.Owner);

            Assert.IsFalse(settlement.IsBuildableByPlayer(PlayerEnum.Player1));
            Assert.IsFalse(settlement.IsBuildableByPlayer(PlayerEnum.Player2));
            Assert.IsFalse(settlement.IsBuildableByPlayer(PlayerEnum.Player3));
        }
        [TestMethod]
        public void TownTest()
        {
            Town town = new Town(PlayerEnum.Player1);

            Assert.AreEqual(PlayerEnum.Player1, town.Owner);

            Assert.IsFalse(town.IsUpgradeable);
            Assert.IsFalse(town.IsBuildableCommunity);

            town.AddPotentionalBuilder(PlayerEnum.Player2);
            Assert.AreNotEqual(PlayerEnum.Player2, town.Owner);

            Assert.IsFalse(town.IsBuildableByPlayer(PlayerEnum.Player1));
            Assert.IsFalse(town.IsBuildableByPlayer(PlayerEnum.Player2));
            Assert.IsFalse(town.IsBuildableByPlayer(PlayerEnum.Player3));
        }
        [TestMethod]
        public void NotBuildableCommunityTest()
        {
            Assert.AreEqual(PlayerEnum.NotPlayer, NotBuildableCommunity.Instance.Owner);

            Assert.IsFalse(NotBuildableCommunity.Instance.IsUpgradeable);
            Assert.IsFalse(NotBuildableCommunity.Instance.IsBuildableCommunity);

            NotBuildableCommunity.Instance.AddPotentionalBuilder(PlayerEnum.Player2);
            Assert.AreNotEqual(PlayerEnum.Player2, NotBuildableCommunity.Instance.Owner);

            Assert.IsFalse(NotBuildableCommunity.Instance.IsBuildableByPlayer(PlayerEnum.Player1));
            Assert.IsFalse(NotBuildableCommunity.Instance.IsBuildableByPlayer(PlayerEnum.Player2));
            Assert.IsFalse(NotBuildableCommunity.Instance.IsBuildableByPlayer(PlayerEnum.Player3));
        }
    }
}
