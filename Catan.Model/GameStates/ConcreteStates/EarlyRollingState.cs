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
            context.Events.OnPlayer(context);
            context.Events.OnDiceThrown(context);
            if (_rollCount == 3)
            {
                int turnsNeededToReachLuckyPlayer = (int)_rolls.First(x => x.Value == _rolls.Values.Max()).Key;
                for (int i = 0; i < turnsNeededToReachLuckyPlayer; i++)
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
