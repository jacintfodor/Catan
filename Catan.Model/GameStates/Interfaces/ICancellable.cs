using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.GameStates;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface ICancellable
    {
        public void Cancel(ICatanContext context);
    }
}
