using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.GameStates.AbstractStates;

namespace Catan.Model.GameStates.ConcreteStates
{
    internal class RogueMovingState : AbstractRogueMovingState
    {
        public override bool IsRogueMovingState => true;

        public override sealed void Cancel(CatanContext context)
        {
            context.Events.OnCancel();
            context.SetContext(new MainState());
        }

        public override sealed void MoveRogue(CatanContext context, int row, int col)
        {
            context.Rogue.Move(row, col);
            context.Events.OnRogueMoved(row, col);

            context.SetContext(new MainState());
        }
    }
}
