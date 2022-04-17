using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class BuildableCommunityViewModel
    {
        public BuildableCommunityViewModel(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public int Column { get; set; }
        public int Row { get; set; }
    }
}
