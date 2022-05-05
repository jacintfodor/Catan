using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board.Components
{
    public interface IVertex
    {
        public PlayerEnum Owner { get; }
        public int Row { get; set; }
        public int Col { get; set; }

        public ICommunity GetCommunity();
        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player);
        public void Build(ICatanGameState state, PlayerEnum player);
        public void Upgrade();
        public void SetNotBuildableCommunity();
    }
}
