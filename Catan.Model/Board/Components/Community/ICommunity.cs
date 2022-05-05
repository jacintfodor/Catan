using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board.Components
{
    public interface ICommunity
    {
        public PlayerEnum Owner { get; }

        public bool IsUpgradeable { get; }

        public void AddPotentionalBuilder(PlayerEnum player);

        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player);
    }
}
