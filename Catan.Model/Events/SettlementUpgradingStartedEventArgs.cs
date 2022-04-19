﻿using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class SettlementUpgradingStartedEventArgs : EventArgs
    {
        public SettlementUpgradingStartedEventArgs(List<IVertex> vertices)
        {
            Vertices = vertices;
        }
        public List<IVertex> Vertices { get; private set; }
    }
}
