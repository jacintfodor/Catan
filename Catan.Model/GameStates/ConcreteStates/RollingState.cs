using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class RollingState : ICatanGameState, IRollable
    {
        public bool IsRollingState => true;

        public void RollDices(ICatanContext context)
        {
            context.FirstDice.roll();
            context.SecondDice.roll();

            context.DistributeResources(context.RolledSum);

            context.Events.OnDiceThrown(context);
            context.Events.OnPlayer(context);

            if (context.RolledSum == 7)
            {
                context.SetContext(new RogueMovingState());
                context.Events.OnRogueMovingStarted();
            }
            else { context.SetContext(new MainState()); }
        }
    }
}
