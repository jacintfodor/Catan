using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class VertexViewModel : ViewModelBase
    {
        private string _building;
        private string _owner;

        public VertexViewModel(string owner, string building, int row, int column)
        {
            Building = building;
            Owner = owner;
            Column = column;
            Row = row;
        }

        public string Building { get => _building; set { _building = value; OnPropertyChanged(); } }
        public string Owner { get => _owner; set { _owner = value; OnPropertyChanged(); } }
        public int Column { get; set; }
        public int Row { get; set; }
    }
}
