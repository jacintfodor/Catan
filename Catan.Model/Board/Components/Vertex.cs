using Catan.Model.Board.Buildings;
using Catan.Model.Context;
using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public class Vertex : IVertex
    {
        public Vertex(PlayerEnum owner, int row, int col, bool isNotBuildable)
        {
            Owner = owner;
            Row = row;
            Col = col;
            IsNotBuildable = isNotBuildable;
        }

        public PlayerEnum Owner { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public bool IsNotBuildable { get; set; }

        public void AddPotentialBuilder(PlayerEnum player)
        {
            
        }

        public bool IsBuildableByPlayer(PlayerEnum player)
        {
            return false;
        }
        public void Build(PlayerEnum player)
        {
            IsNotBuildable = true;
        }
        public void Upgrade()
        {}

    }
}