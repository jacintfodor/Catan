using Catan.Model.Enums;

namespace Catan.ViewModel.Vertex
{
    public class VertexViewModel : ViewModelBase
    {
        private CommunityEnum _community;
        private PlayerEnum _owner;
        private int _row;
        private int _col;

        //TODO owner enum, community enum
        public VertexViewModel(int row, int column, PlayerEnum owner, CommunityEnum community)
        {
            Row = row;
            Column = column;
            Community = community;
            Owner = owner;
        }

        public int Column { get => _col; set { _col = value; OnPropertyChanged(); OnPropertyChanged(nameof(Left)); } }
        public int Row { get => _row; set { _row = value; OnPropertyChanged(); OnPropertyChanged(nameof(Top)); } }

        public string Left { get => (Column * 30 - 6).ToString(); }
        public string Top { get => (Row * 60 - 6).ToString(); }

        public CommunityEnum Community { get => _community; set { _community = value; OnPropertyChanged(); } }
        public PlayerEnum Owner { get => _owner; set { _owner = value; OnPropertyChanged(); } }


        #region Converters
        private Dictionary<CommunityEnum, int> _communityToSize = new Dictionary<CommunityEnum, int>()
        {
            {CommunityEnum.NotBuildableCommunity, 0},
            {CommunityEnum.BuildableCommunity, 0},
            {CommunityEnum.Settlement, 12},
            {CommunityEnum.Town, 16}
        };

        private Dictionary<PlayerEnum, string> _ownerToColor = new Dictionary<PlayerEnum, string>()
        {
            {PlayerEnum.NotPlayer, "White" },
            {PlayerEnum.Player1, "Red" },
            {PlayerEnum.Player2, "Yellow" },
            {PlayerEnum.Player3, "Blue" },
        };

        public string Color { get => _ownerToColor[_owner]; }

        public string Size { get => _communityToSize[_community].ToString(); }
        #endregion
    }
}
