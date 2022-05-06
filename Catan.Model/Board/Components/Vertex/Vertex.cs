using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board.Components.Vertex
{
    //TODO set internal once we use TDOs in VM
    internal class Vertex : IVertex
    {
        private ICommunity _community = new BuildableCommunity();

        public Vertex(int row, int col, ICommunity? community = null)
        {
            Row = row;
            Col = col;
            _community ??= community;
        }

        public PlayerEnum Owner => _community.Owner;

        public CommunityEnum Type => _community.Type;

        public bool IsUpgradeable => _community.IsUpgradeable;

        public int Row { get; private set; }
        public int Col { get; private set; }

        public void AddPotentialBuilder(PlayerEnum player)
        {
            _community.AddPotentionalBuilder(player);
        }

        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player)
        {
            return _community.IsBuildableByPlayer(state, player);
        }

        public void BuildSettlement(ICatanGameState state, PlayerEnum player)
        {
            if (!_community.IsBuildableByPlayer(state, player)) throw new InvalidOperationException("NotBuildableByPlayer");

            _community = new Settlement(player);
        }

        public void UpgradeToTown()
        {
            if (!_community.IsUpgradeable) throw new InvalidOperationException("NotUpgradableByPlayer");

            _community = new Town(Owner);
        }

        public void SetNotBuildableCommunity()
        {
            if (_community.Type == CommunityEnum.Town || _community.Type == CommunityEnum.Settlement) throw new InvalidOperationException("BuiltCommunity");

            _community = NotBuildableCommunity.Instance;
        }
    }
}