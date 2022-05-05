using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;

namespace Catan.Model.Events.Eventargs
{
    public class PlayerEventArgs : EventArgs
    {
        public List<IPlayer> Players { get; private set; }

        public PlayerEventArgs(List<IPlayer> p)
        {
            Players = p;
        }

    }
}
