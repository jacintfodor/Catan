using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Events
{
    public  class DicesThrownEventArg : EventArgs
    {
        public int FirstDice { get; private set; }
        public int SecondDice { get; private set;}

        public DicesThrownEventArg(int a, int b)
        {
            FirstDice = a;
            SecondDice = b;
        }
    }
}
