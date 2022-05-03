using Catan.Model.Board;
using Catan.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface ISettlementBuildable
    {
        public void BuildSettleMent(ICatanContext context, ICatanEvents events, ICatanBoard board, IPlayer currentPlayer, int row, int col);
    }
}
