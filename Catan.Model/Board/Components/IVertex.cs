using Catan.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Board.Components
{
    interface IVertex
    {
        public PlayerEnum Owner { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsNotBuildable { get; set; }

        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(PlayerEnum player);
        public void Build(PlayerEnum player);
        public void Upgrade();
    }
}
