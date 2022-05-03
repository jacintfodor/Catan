using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context
{
    public interface ITitle
    {
        public IPlayer Owner { get; }
        public int Score { get;  }
        public void ProcessOwner(IPlayer titleContester);
    }
}
