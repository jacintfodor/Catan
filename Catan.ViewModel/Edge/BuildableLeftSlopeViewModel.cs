﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class BuildableLeftSlopeViewModel : ViewModelBase
    {
        public BuildableLeftSlopeViewModel(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
