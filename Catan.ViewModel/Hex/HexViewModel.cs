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
        private string _resource;
        private int _number;

        public HexViewModel(string resource, int number, int row, int column)
        {
            Resource = resource;
            Number = number;
            Column = column;
            Row = row;
        }

        public string Resource { get => _resource; set { _resource = value; OnPropertyChanged(); } }
        public int Number { get => _number; set { _number = value; OnPropertyChanged(); } }
        public int Column { get; set; }
        public int Row { get; set; }

    }
}
