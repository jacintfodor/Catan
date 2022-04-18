using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class BuildableRoad : IRoad
    {
        HashSet<PlayerEnum> _potentialBuilders;

        public BuildableRoad()
        {
            _potentialBuilders = new HashSet<PlayerEnum>();
            Owner = PlayerEnum.NotPlayer;
            IsBuildable = true;
        }

        public PlayerEnum Owner { get; set; }
        public bool IsBuildable { get; set; }
        public void AddPotentialBuilder(PlayerEnum player)
        {
            _potentialBuilders.Add(player);
        }
        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return _potentialBuilders.Contains(player);
        }

    }
}
