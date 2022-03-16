using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Buildings
{
    public class Town : Building
    {
        override public int score() { return 2; }
        override public int multiplier() { return 2; }
        override public int[] buildCost() { return new int[] {3, 3, 0, 0, 0}; }
    }
}
