using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel

{
    public class BuildableRightSlopeViewModel : ViewModelBase
    {
        private int? _row;
        private int? _col;
        public BuildableRightSlopeViewModel(int? row, int? column)
        {
            Row = row;
            Column = column;
        }
        public int? Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int? Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }
       
        public string Top
        {
            get => (Row * 30 - 3).ToString();
        }

        private int Offset { get => (Row % 2 == 0) ? 0 : 30; }

        public string Left
        {
            get => (Offset + Column * 30).ToString();
        }

        public DelegateCommand BuildCommand { get; set; }
    }
}
