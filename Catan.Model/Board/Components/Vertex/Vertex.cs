using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;

namespace Catan.Model.Board.Components
{
    //TODO set internal once we use TDOs in VM
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

        public CommunityEnum Type => _community.Type;

        public int Row { get; set; }
        public int Col { get; set; }

        public void AddPotentialBuilder(PlayerEnum player)
        {
            _community.AddPotentionalBuilder(player);
        }

        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player)
        {
            return _community.IsBuildableByPlayer(state, player);
        }

        public void Build(ICatanGameState state, PlayerEnum player)
        {
            if (!_community.IsBuildableByPlayer(state, player)) throw new InvalidOperationException("NotBuildableByPlayer");
            
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
            if (_community.Type == CommunityEnum.Town || _community.Type == CommunityEnum.Settlement) throw new InvalidOperationException("BuiltCommunity");
            
            _community = NotBuildableCommunity.Instance;
        }
    }
}