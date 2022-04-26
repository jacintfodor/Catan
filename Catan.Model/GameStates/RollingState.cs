using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates
{
    internal class RollingState : AbstractRollingState
    {
        public override sealed bool IsEarlyRollingState => false;

        public override sealed bool IsRollingState => true;

        public override sealed void RollDices(CatanContext context)
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
