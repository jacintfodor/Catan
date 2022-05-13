using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class SettlementBuildingState : ICatanGameState, ISettlementBuildable, ICancellable
    {
        public bool IsSettlementBuildingState => true;

        public void BuildSettleMent(ICatanContext context, int row, int col)
        {

            context.Board.BuildSettlement(row, col, context.State, context.CurrentPlayer.ID);
            context.Events.OnSettlementBuilt(context, row, col, context.CurrentPlayer.ID);
            
            context.CurrentPlayer.SpendSettlementCard();
            context.CurrentPlayer.ReduceResources(Constants.SettlementCost);
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
