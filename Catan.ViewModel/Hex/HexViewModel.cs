using Catan.Model.Enums;

namespace Catan.ViewModel.Hex
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

        public double Top
        {
            get => (Row * 0.1875);
        }

        private int Offset { get => Row % 2 == 0 ? 0 : 30; }

        public double Left
        {
            get => ((Offset + Column * 60)/300.0);
        }

        private Dictionary<ResourceEnum, string> _resourceToColor = new Dictionary<ResourceEnum, string>()
        {
            {ResourceEnum.Crop, "Goldenrod" },
            {ResourceEnum.Ore, "SlateGray" },
            {ResourceEnum.Wood, "ForestGreen" },
            {ResourceEnum.Brick, "Firebrick" },
            {ResourceEnum.Wool, "PaleGreen" },
            {ResourceEnum.Desert, "black" }
        };
        public string Color { get => _resourceToColor[Resource]; }

        public int ZIndex { get => 0; }

        #endregion

    }
}
