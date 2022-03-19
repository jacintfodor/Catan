using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context.Titles
{
    internal class LongestRoadOwner : ITitle
    {
        public void processOwner(IPlayer titleContester)
        {
            throw new NotImplementedException();
        }

        public int score()
        {
            return 2;
        }
    }
}
