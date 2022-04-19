using Catan.Model.Enums;
namespace Catan.Model.Board.Components
{
    public interface IVertex
    {
        public PlayerEnum Owner { get; }
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsBuildable { get; }

        public ICommunity GetCommunity();
        public void AddPotentialBuilder(PlayerEnum player);
        public bool IsBuildableByPlayer(PlayerEnum player);
        public void Build(PlayerEnum player);
        public void Upgrade();
        public void SetNotBuildableCommunity();
    }
}
