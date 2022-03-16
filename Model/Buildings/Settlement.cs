using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.buildings
{
    public class Settlement : Building
    {
        override public int score() { return 1; }
        override public int multiplier() { return 1;}
        override public int[] buildCost() {return new int[]{1,0,1,1,1};}
    }
}
