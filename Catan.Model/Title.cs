using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model
{
    interface Title
    {
        public int score();
        public void processOwner();
    }
}
