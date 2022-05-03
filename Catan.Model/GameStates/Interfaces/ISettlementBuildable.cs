using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Board;
using Catan.Model.Context;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface ISettlementBuildable
    {
        public void BuildSettleMent(CatanContext context, CatanBoard board, IPlayer currentPlayer, int row, int col);
    }
}
