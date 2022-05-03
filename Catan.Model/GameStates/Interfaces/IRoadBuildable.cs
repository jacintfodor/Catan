using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates
{
    internal interface IRoadBuildable
    {
        public void BuildRoad(ICatanContext context, int row, int col);
    }
}
