using Catan.Model.Context.Players;

namespace Catan.Model.Board.Buildings
{
    public abstract class Building
    {
        public abstract int score();
        public abstract int amount();
        public abstract bool isBuildable();
        public abstract List<Player> canBuild();
    }
}
