using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.ViewModel
{
    public class BuildableCommunityViewModel : ViewModelBase
    {
        private int? _row;
        private int? _col;

        public DelegateCommand BuildCommand { get; set; }

        public BuildableCommunityViewModel(int? row, int? column)
        {
            Row = row;
            Column = column;
        }
        public int? Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int? Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }

        public string Left { get => (Column * 30 - 6).ToString(); }
        public string Top { get => (Row * 60 - 6).ToString(); }
    }
}
