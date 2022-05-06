using Catan.Model.Enums;

namespace Catan.Model.Board.Components.Edge
{
    public class BuildableRoad : IRoad
    {
        HashSet<PlayerEnum> _potentialBuilders = new();

        public PlayerEnum Owner => PlayerEnum.NotPlayer;
        public bool IsBuildable => true;
        public void AddPotentialBuilder(PlayerEnum player)
        {
            if (player == PlayerEnum.NotPlayer) throw new ArgumentException("InvalidPlayer");

            _potentialBuilders.Add(player);
        }
        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return _potentialBuilders.Contains(player);
        }

    }
}
