using Catan.Model.GameStates.Interfaces;
using Catan.Model.DTOs;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class EarlySettlementBuildingState : ICatanGameState, ISettlementBuildable
    {
        readonly int _turnCount;

        public EarlySettlementBuildingState(int turnCount)
        {
            _turnCount = turnCount;
        }

        public bool IsEarlySettlementBuildingState => true;


        public void BuildSettleMent(ICatanContext context, int row, int col)
        {
            context.CurrentPlayer.BuildSettlement();
            context.Events.OnPlayerUpdated(context);

            context.Board.BuildSettlement(row, col, context.State, context.CurrentPlayer.ID);
            context.Events.OnSettlementBuilt(context, row, col, context.CurrentPlayer.ID);

            List<EdgeDTO> list =
                context.Board.GetNeighborEdgesOfVertex(row, col)
                .Where(e => e.IsBuildableByPlayer(context.CurrentPlayer.ID))
                .Select(e => Mapping.Mapper.Map<EdgeDTO>(e))
                .ToList();
            
            context.Events.OnRoadBuildingStarted(list);

            context.SetContext(new EarlyRoadBuildingState(_turnCount + 1));
        }
    }
}
