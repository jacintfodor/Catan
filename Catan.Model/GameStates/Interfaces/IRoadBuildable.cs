using Catan.Model.Board;
using Catan.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates
{
    internal interface IRoadBuildable
    {
        public void BuildRoad(ICatanContext context, ICatanEvents events, ICatanBoard board, ITitle longestRoad, IPlayer currentPlayer, int row, int col);
    }
}
