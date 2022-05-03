using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;
using Catan.Model.Board;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class EarlyRollingState : ICatanGameState, IRollable
    {
        private int _rollCount = 0;
        private readonly Dictionary<PlayerEnum, int> _rolls = new();

        public bool IsEarlyRollingState => true;

        public void RollDices(CatanContext context, CatanBoard board, CubeDice firstDice, CubeDice secondDice, IPlayer currentPlayer)
        {
            ++_rollCount;
            firstDice.roll();
            secondDice.roll();
            _rolls.Add(currentPlayer.ID, context.RolledSum);
            context.NextPlayer();

            context.OnDiceThrown(context);
            if (_rollCount == 3)
            {
                //Im pretty sure thats wrong (int)_rolls.Keys.Max() thats gonna always return p3
                for (int i = 0; i < (int)_rolls.Keys.Max(); i++)
                    context.NextPlayer();


                //TODO put this into context as it has nothing to do with rolls, but first make sure to prepare the code to use IsBuildableByPlayer before using multiple dispatch
                var list = board.GetVerticesEnumerable().ToList().Where(v => v.IsBuildable).ToList();
                context.OnSettlementBuildingStarted(list);
                context.OnPlayer(context);
                context.SetContext(new EarlySettlementBuildingState(0));
            }
        }
    }
}
