using Catan.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Board.Components
{
    interface ICommunity
    {
        public PlayerEnum Owner { get; set; }

        public bool IsUpgradable { get; set; }

        public bool IsBuildableCommunity { get; set; }

        public void AddPotentioalBuilder(PlayerEnum player);

        public bool IsBuildableByPlayer(PlayerEnum player);
    }
}
