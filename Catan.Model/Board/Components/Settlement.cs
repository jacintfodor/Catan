using Catan.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Board.Components
{
    public class Settlement : ICommunity
    {
        public Settlement(PlayerEnum owner)
        {
            Owner = owner;
            IsUpgradable = true;
            IsBuildableCommunity = false;
        }

        public PlayerEnum Owner { get; set; }

        public bool IsUpgradable { get; set; }

        public bool IsBuildableCommunity { get; set; }

        public void AddPotentionalBuilder(PlayerEnum player) { }

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return this.Owner == player;
        }
    }
}
