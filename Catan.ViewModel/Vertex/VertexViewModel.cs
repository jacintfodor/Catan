using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class VertexViewModel : ViewModelBase
    {
        private string _community;
        private string _owner;

        public VertexViewModel(int row, int column, string owner, string community)
        {
            Row = row;
            Column = column;
            Community = community;
            Owner = owner;
        }
        public int Row { get; set; }
        public int Column { get; set; }

        public string Community { get => _community; set { _community = value; OnPropertyChanged(); } }
        public string Owner { get => _owner; set { _owner = value; OnPropertyChanged(); } }
    }
}
