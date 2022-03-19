using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context
{
    internal interface ITitle
    {
        int score();
        void processOwner(IPlayer titleContester);
    }
}
