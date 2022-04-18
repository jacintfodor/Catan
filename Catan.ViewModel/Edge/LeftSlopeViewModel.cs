using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class LeftSlopeViewModel : ViewModelBase
    {
        public LeftSlopeViewModel(int row, int column, string owner)
        {
            Row = row;
            Column = column;
            Owner = owner;
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Owner { get; set; }
    }
}
