using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class EarlyRollingState : AbstractRollingState
    {
        private int _rollCount = 0;
        private Dictionary<PlayerEnum, int> _rolls = new Dictionary<PlayerEnum, int>();

        public override sealed bool IsEarlyRollingState => true;
        public override sealed bool IsRollingState => false;

        public override sealed void RollDices(CatanContext context)
        {
            ++_rollCount;
            context.FirstDice.roll();
            context.SecondDice.roll();
            _rolls.Add(context.CurrentPlayer.ID, context.RolledSum);
            context.NextPlayer();

            context.Events.OnDiceThrown(context);
            if (_rollCount == 3)
            {
                for (int i = 0; i < (int)_rolls.Keys.Max(); i++)
                    context.NextPlayer();

                var list = context.Board.GetVerticesEnumerable().ToList().Where(v => v.IsBuildable).ToList();
                context.Events.OnSettlementBuildingStarted(list);
                context.Events.OnPlayer(context);
                context.SetContext(new EarlySettlementBuildingState(0));
            }
        }
    }
}
