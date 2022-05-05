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
    //TODO set internal
    public class EarlyRollingState : ICatanGameState, IRollable
    {
        private int _rollCount = 0;
        private readonly Dictionary<PlayerEnum, int> _rolls = new();

        public bool IsEarlyRollingState => true;

        public void RollDices(ICatanContext context)
        {
            
            ++_rollCount;
            context.FirstDice.roll();
            context.SecondDice.roll();
            _rolls.Add(context.CurrentPlayer.ID, context.RolledSum);
            context.NextPlayer();
            context.Events.OnPlayer(context);
            context.Events.OnDiceThrown(context);
            if (_rollCount == 3)
            {
                int turnsNeededToReachLuckyPlayer = (int)_rolls.First(x => x.Value == _rolls.Values.Max()).Key;
                for (int i = 0; i < turnsNeededToReachLuckyPlayer; i++)
                    context.NextPlayer();

                var list = context.Board.GetBuildableSettlementsByPlayer(this, context.CurrentPlayer.ID);
                context.Events.OnSettlementBuildingStarted(list);
                context.Events.OnPlayer(context);
                context.SetContext(new EarlySettlementBuildingState(0));
            }
        }
    }
}
