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

        public VertexViewModel(string owner, string community, int row, int column)
        {
            Community = community;
            Owner = owner;
            Column = column;
            Row = row;
        }

        public string Community { get => _community; set { _community = value; OnPropertyChanged(); } }
        public string Owner { get => _owner; set { _owner = value; OnPropertyChanged(); } }
        public int Column { get; set; }
        public int Row { get; set; }
    }
}
