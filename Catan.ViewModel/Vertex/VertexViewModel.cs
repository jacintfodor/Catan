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
        private int _row;
        private int _col;


        //TODO owner enum, community enum
        public VertexViewModel(int row, int column, string owner, string community)
        {
            Row = row;
            Column = column;
            Community = community;
            Owner = owner;
        }
        public int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }

        public string Left { get => (Column*30 -6).ToString(); }
        public string Top { get => (Row * 60 -6).ToString(); }

        public string Community { get => _community; set { _community = value; OnPropertyChanged(); } }
        public string Owner { get => _owner; set { _owner = value; OnPropertyChanged(); } }
    
    
    }
}
