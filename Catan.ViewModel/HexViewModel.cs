using Catan.Model.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class HexViewModel : ViewModelBase
    {
        public HexViewModel(ResourceEnum resource, int number)
        {
            Resource = resource;
            Number = number;
        }

        public ResourceEnum Resource { get; set; }
        public int Number { get; set; }

    }
}
