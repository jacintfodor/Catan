using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board
{
    public interface ICatanBoard
    {
        void BuildRoad(int row, int col, PlayerEnum player);
        void BuildSettlement(int row, int col, ICatanGameState state, PlayerEnum player);
        IEdge GetEdge(int row, int col);
        IEnumerable<IEdge> GetEdgesEnumerable();
        List<IEdge> GetEdgesofEdge(int row, int col);
        IEnumerable<IHex> GetHexesEnumerable();
        List<IEdge> GetNeighborEdgesOfVertex(int row, int col);
        List<IVertex> GetNeighborVerticesOfVertex(int row, int col);
        List<IVertex> GetNeighbourVerticesOfEdge(int row, int col);
        IEnumerable<IVertex> GetVerticesEnumerable();
        List<IVertex> GetVerticesOfHex(int row, int col);
        void UpgradeSettlement(int row, int col);

        int CalculateLongestRoadFromEdge(int row, int col, PlayerEnum id);

        List<IEdge> GetBuildableRoadsByPlayer(PlayerEnum id);

        List<IVertex> GetBuildableSettlementsByPlayer(ICatanGameState state, PlayerEnum id);

        List<IVertex> GetUpgradeableSettlementsByPlayer(PlayerEnum id);
        
    }
}