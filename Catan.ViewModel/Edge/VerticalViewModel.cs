﻿
namespace Catan.ViewModel
{
    public class VerticalViewModel :ViewModelBase
    {
        public VerticalViewModel(int row, int column, string owner)
        {
            Row = row;
            Column = column;
            Owner = owner;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public string Owner { get; set; }

        public String Top
        {
            get => (Row * 30 - 30).ToString();
        }

        private int Offset { get => (Row % 2 == 0) ? 0 : 30; }

        public String Left
        {
            get => (Offset + Column * 30 -30 -3).ToString();
        }
    }
}
