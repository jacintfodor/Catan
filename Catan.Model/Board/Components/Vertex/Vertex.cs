using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Vertex : IVertex
    {
        private ICommunity _community;

        public Vertex(int row, int col)
        {
            Owner = PlayerEnum.NotPlayer;
            Row = row;
            Col = col;
            IsNotBuildable = false;
            _community = new BuildableCommunity();
        }

        public PlayerEnum Owner { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsNotBuildable { get; set; } = false;

        public void AddPotentialBuilder(PlayerEnum player)
        {
            _community.AddPotentionalBuilder(player);
        }

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return _community.IsBuildableByPlayer(player);
        }

        public void Build(PlayerEnum player)
        {
            IsNotBuildable = true;
            _community = new Settlement(player);
            Owner = player;
        }

        public void Upgrade()
        {
            if (_community.IsUpgradeable)
                _community = new Town(Owner);
        }

        public ICommunity GetCommunity()
        {
            return _community;
        }

        public void SetNotBuildableCommunity()
        {
            _community = NotBuildableCommunity.Instance;
            IsNotBuildable = true;
        }
    }
}