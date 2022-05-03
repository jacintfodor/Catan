using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface ISettlementUpgradeable
    {
        public void UpgradeSettleMentToTown(CatanContext context, int row, int col);
    }
}
