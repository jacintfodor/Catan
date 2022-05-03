using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Board;
using Catan.Model.Context;

namespace Catan.Model.GameStates
{
    internal interface IRoadBuildable
    {
        public void BuildRoad(CatanContext context, CatanBoard board, IPlayer currentPlayer, ITitle longestRoad, int row, int col);
    }
}
