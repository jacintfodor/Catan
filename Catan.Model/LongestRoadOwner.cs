using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model
{
    public class LongestRoadOwner : Title
    {
        public string owner = "";

        public int score() {
            return 2;
        }

        //needs grap
        public void processOwner() {
            owner = "to be Implemented";
        }
    }
}
