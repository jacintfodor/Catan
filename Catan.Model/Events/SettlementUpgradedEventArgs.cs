﻿using Catan.Model.Enums;


namespace Catan.Model.Events
{
    public class SettlementUpgradedEventArgs : EventArgs
    {
        public SettlementUpgradedEventArgs(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
    }
}
