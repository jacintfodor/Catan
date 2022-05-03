using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Board;
using Catan.Model.Context;
using Catan.Model.GameStates;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IRollable
    {
        public void RollDices(ICatanContext context, ICatanEvents events, ICatanBoard board, ICubeDice firstDice, ICubeDice secondDice, IPlayer currentPlayer);
    }
}
