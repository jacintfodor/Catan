using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;

namespace Catan.Model.Events.Eventargs
{
    public class DicesRolledEventArg : EventArgs
    {
        public int FirstDice { get; private set; }
        public int SecondDice { get; private set; }


        

        public DicesRolledEventArg(int a, int b)
        {
            FirstDice = a;
            SecondDice = b;
        }
    }
}
