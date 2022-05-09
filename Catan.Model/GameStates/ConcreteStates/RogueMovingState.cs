using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class RogueMovingState : ICatanGameState, IRogueMovable, ICancellable
    {
        public bool IsRogueMovingState => true;

        public void Cancel(ICatanContext context)
        {
            context.Events.OnCancelled();
            context.SetContext(new MainState());
        }

        public void MoveRogue(ICatanContext context, int row, int col)
        {
            context.Rogue.Move(row, col);
            context.Events.OnRogueMoved(row, col);

            context.SetContext(new MainState());
        }
    }
}
