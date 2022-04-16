﻿using Catan.Model.Enums;

namespace Catan.Model.Board.Components.Edge
{
    interface IRoad
    {
        public PlayerEnum Owner { get; set; }

        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(PlayerEnum player);
    }
}
