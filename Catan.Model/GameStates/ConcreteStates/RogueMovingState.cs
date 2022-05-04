using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class RogueMovingState : ICatanGameState, IRogueMovable, ICancellable
    {
        public bool IsRogueMovingState => true;

        public void Cancel(ICatanContext context, ICatanEvents events)
        {
            events.OnCancel();
            context.SetContext(new MainState());
        }

        public void MoveRogue(ICatanContext context, ICatanEvents events, IRogue rogue, int row, int col)
        {
            rogue.Move(row, col);
            events.OnRogueMoved(row, col);

            context.SetContext(new MainState());
        }
    }
}
