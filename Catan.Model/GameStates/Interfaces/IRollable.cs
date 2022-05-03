using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.GameStates;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IRollable
    {
        public void RollDices(ICatanContext context);
    }
}
