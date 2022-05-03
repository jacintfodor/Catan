using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IRogueMovable
    {
        public void MoveRogue(CatanContext context, Rogue rogue, int row, int col);
    }
}
