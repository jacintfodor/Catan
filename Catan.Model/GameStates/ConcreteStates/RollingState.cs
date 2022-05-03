using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Board;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class RollingState : ICatanGameState, IRollable
    {
        public bool IsRollingState => true;

        public void RollDices(ICatanContext context, ICatanEvents events, ICatanBoard board, ICubeDice firstDice, ICubeDice secondDice, IPlayer currentPlayer)
        {
            firstDice.roll();
            secondDice.roll();

            context.DistributeResources(context.RolledSum);

            events.OnDiceThrown(context);
            events.OnPlayer(context);

            if (context.RolledSum == 7)
            {
                context.SetContext(new RogueMovingState());
                events.OnRogueMovingStarted();
            }
            else { context.SetContext(new MainState()); }
        }
    }
}
