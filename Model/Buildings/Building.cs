using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model
{
    //Building. can be nothing city or settlement. to be implemented
    public abstract class Building
    {
        abstract public int score();
        abstract public int multiplier();
        abstract public int[] buildCost();
    }
}
