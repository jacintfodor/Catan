using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Vertex : IVertex
    {
        private ICommunity _community;

        public Vertex(int row, int col)
        {
            Row = row;
            Col = col;
            _community = new BuildableCommunity();
        }

        public PlayerEnum Owner => _community.Owner;
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsBuildable => _community.IsBuildableCommunity;

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
            if (!_community.IsBuildableCommunity) throw new NotImplementedException();
            _community = new Settlement(player);
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
            if (_community.IsBuildableCommunity)
                _community = NotBuildableCommunity.Instance;
        }
    }
}