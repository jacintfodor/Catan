using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class LeftSlopeViewModel : ViewModelBase
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public int Owner { get; set; }
    }
}
