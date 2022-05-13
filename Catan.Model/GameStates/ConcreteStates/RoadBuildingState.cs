using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class RoadBuildingState : ICatanGameState, IRoadBuildable, ICancellable
    {
        public bool IsRoadBuildingState => true;

        public void BuildRoad(ICatanContext context, int row, int col)
        {
            context.Board.BuildRoad(row, col, context.CurrentPlayer.ID);
            context.Events.OnRoadBuilt(context, row, col, context.CurrentPlayer.ID);

            context.CurrentPlayer.LengthOfLongestRoad = context.Board.CalculateLongestRoadFromEdge(row, col, context.CurrentPlayer.ID);

            var currentLongestRoadOwner = context.LongestRoadOwner.Owner;
            context.LongestRoadOwner.ProcessOwner(context.CurrentPlayer);
            var updatedLongestRoadOwner = context.LongestRoadOwner.Owner;
            if (updatedLongestRoadOwner != currentLongestRoadOwner) context.Events.OnLongestRoadEarned();

            context.CurrentPlayer.SpendRoadCards();
            context.CurrentPlayer.ReduceResources(Constants.RoadCost);
            context.Events.OnPlayerUpdated(context);
            context.SetContext(new MainState());
        }

        public void Cancel(ICatanContext context)
        {
            context.Events.OnCancelled();
            context.SetContext(new MainState());
        }
    }
}
