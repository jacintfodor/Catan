using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context
{
    internal interface ITitle
    {
        public int Score { get;  }
        public void ProcessOwner(IPlayer titleContester);
    }
}
