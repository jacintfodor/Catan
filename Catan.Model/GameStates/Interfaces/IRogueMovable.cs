using Catan.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IRogueMovable
    {
        public void MoveRogue(ICatanContext context, ICatanEvents events, IRogue rogue, int row, int col);
    }
}
