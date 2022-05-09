using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class RollingState : ICatanGameState, IRollable
    {
        public bool IsRollingState => true;

        public void RollDices(ICatanContext context)
        {
            context.FirstDice.roll();
            context.SecondDice.roll();

            context.DistributeResources(this);

            context.Events.OnDicesRolled(context);
            context.Events.OnPlayerUpdated(context);

            if (context.RolledSum == 7)
            {
                context.SetContext(new RogueMovingState());
                context.Events.OnRogueMovingStarted();
            }
            else { context.SetContext(new MainState()); }
        }
    }
}
