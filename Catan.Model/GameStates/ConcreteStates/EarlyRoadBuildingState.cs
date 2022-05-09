using Catan.Model.DTOs;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class EarlyRoadBuildingState : ICatanGameState, IRoadBuildable
    {
        private int _turnCount = 0;

        public EarlyRoadBuildingState(int turnCount)
        {
            _turnCount = turnCount;
        }

        public bool IsEarlyRoadBuildingState => true;

        public void BuildRoad(ICatanContext context, int row, int col)
        {
            context.Board.BuildRoad(row, col, context.CurrentPlayer.ID);
            context.Events.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID);

            context.CurrentPlayer.LengthOfLongestRoad = context.Board.CalculateLongestRoadFromEdge(row, col, context.CurrentPlayer.ID);
            context.LongestRoadOwner.ProcessOwner(context.CurrentPlayer);

            //TODO remove magic number 6
            if (_turnCount > 6 && _turnCount < 0) ; //TODO throw error

            else if (_turnCount == 6)
            {
                context.DistributeResources(this);
                context.SetContext(new RollingState());
            }
            else
            {
                List<VertexDTO> list =
                    context.Board.GetBuildableSettlementsByPlayer(this, context.CurrentPlayer.ID)
                    .Select(v => Mapping.Mapper.Map<VertexDTO>(v))
                    .ToList();         
                context.Events.OnSettlementBuildingStarted(list);

                context.SetContext(new EarlySettlementBuildingState(_turnCount));
            }

            context.NextPlayer();
            context.CurrentPlayer.BuildRoad();
            context.Events.OnPlayerUpdated(context);
        }
    }
}
