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

        public void RollDices(CatanContext context, CatanBoard board, CubeDice firstDice, CubeDice secondDice, IPlayer currentPlayer)
        {
            firstDice.roll();
            secondDice.roll();

            context.DistributeResources(context.RolledSum);

            context.OnDiceThrown(context);
            context.OnPlayer(context);

            if (context.RolledSum == 7)
            {
                context.SetContext(new RogueMovingState());
                context.OnRogueMovingStarted();
            }
            else { context.SetContext(new MainState()); }
        }
    }
}
