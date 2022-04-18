using Catan.Model.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Enums;

namespace Catan.ViewModel
{
    public class HexViewModel : ViewModelBase
    {
        private ResourceEnum _resource;
        private int _number;
        private int _row;
        private int _col;

        public HexViewModel(ResourceEnum resource, int number, int row, int column)
        {
            Resource = resource;
            Number = number;
            Column = column;
            Row = row;
        }

        public ResourceEnum Resource { get => _resource; set { _resource = value; OnPropertyChanged(); OnPropertyChanged(nameof(Color)); } }
        public int Number { get => _number; set { _number = value; OnPropertyChanged(); } }
        public int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); OnPropertyChanged(nameof(Left)); } }
        #region converted values

        public string Top
        {
            get => (Row * 60).ToString();
        }

        private int Offset { get => (Row % 2 == 0) ? 0 : 30; }

        public string Left
        {
            get => (Offset + Column * 60).ToString();
        }

        private Dictionary<ResourceEnum, string> _resourceToColor = new Dictionary<ResourceEnum, string>()
        {
            {ResourceEnum.Ore, "gray" },
            {ResourceEnum.Wool, "white" },
            {ResourceEnum.Brick, "red" },
            {ResourceEnum.Crop, "orange" },
            {ResourceEnum.Wood, "brown" },
            {ResourceEnum.Desert, "black" }
        };
        public string Color { get => _resourceToColor[Resource]; }

        #endregion

    }
}
