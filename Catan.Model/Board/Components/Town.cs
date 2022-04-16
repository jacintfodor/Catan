﻿using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Town : ICommunity
    {
        public Town(PlayerEnum owner)
        {
            Owner = owner;
            IsUpgradable = false;
            IsBuildableCommunity = false;
        }

        public PlayerEnum Owner { get; set; }

        public bool IsUpgradable { get; set; }

        public bool IsBuildableCommunity { get; set; }

        public void AddPotentionalBuilder(PlayerEnum player) {}

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return this.Owner == player;
        }
    }
}
