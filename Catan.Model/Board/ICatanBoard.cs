using Catan.Model.Board.Components;
using Catan.Model.Enums;

namespace Catan.Model.Board
{
    public interface ICatanBoard
    {
        void BuildRoad(int row, int col, PlayerEnum player);
        void BuildSettlement(int row, int col, PlayerEnum player);
        IEdge GetEdge(int row, int col);
        IEnumerable<IEdge> GetEdgesEnumerable();
        List<IEdge> GetEdgesofEdge(int row, int col);
        IEnumerable<IHex> GetHexesEnumerable();
        List<IEdge> GetNeighborEdgesOfVertex(int row, int col);
        List<IVertex> GetNeighborVerticesOfVertex(int row, int col);
        List<IVertex> GetNeighbourVerticesOfEdge(int row, int col);
        IEnumerable<IVertex> GetVerticesEnumerable();
        List<IVertex> GetVerticesOfHex(int row, int col);
        void MarkNeighbouringVerticesNotBuildable(int row, int col);
        void UpgradeSettlement(int row, int col);
    }
}