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
    internal class EarlyRollingState : ICatanGameState, IRollable
    {
        private int _rollCount = 0;
        private readonly Dictionary<PlayerEnum, int> _rolls = new();

        public bool IsEarlyRollingState => true;

        public void RollDices(ICatanContext context, ICatanEvents events, ICatanBoard board, ICubeDice firstDice, ICubeDice secondDice, IPlayer currentPlayer)
        {
            ++_rollCount;
            firstDice.roll();
            secondDice.roll();
            _rolls.Add(currentPlayer.ID, context.RolledSum);
            context.NextPlayer();

            events.OnDiceThrown(context);
            if (_rollCount == 3)
            {
                //pretty sure this one returns player 3 all the time
                for (int i = 0; i < (int)_rolls.Keys.Max(); i++)
                    context.NextPlayer();

                //TODO move this to elsewhere
                var list = board.GetVerticesEnumerable().ToList().Where(v => v.IsBuildable).ToList();
                events.OnSettlementBuildingStarted(list);
                events.OnPlayer(context);
                context.SetContext(new EarlySettlementBuildingState(0));
            }
        }
    }
}
