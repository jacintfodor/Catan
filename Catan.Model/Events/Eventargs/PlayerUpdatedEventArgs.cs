using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;

namespace Catan.Model.Events.Eventargs
{
    public class PlayerUpdatedEventArgs : EventArgs
    {
        public List<IPlayer> Players { get; private set; }

        public PlayerUpdatedEventArgs(List<IPlayer> p)
        {
            Players = p;
        }

    }
}
