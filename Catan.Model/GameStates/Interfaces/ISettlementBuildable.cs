using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface ISettlementBuildable
    {
        public void BuildSettleMent(CatanContext context, int row, int col);
    }
}
