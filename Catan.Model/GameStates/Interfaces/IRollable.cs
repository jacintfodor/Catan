using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.GameStates;
using Catan.Model.Board;
using Catan.Model.Context;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IRollable
    {
        public void RollDices(CatanContext context, CatanBoard board, CubeDice firstDice, CubeDice secondDice, IPlayer currentPlayer);
    }
}
