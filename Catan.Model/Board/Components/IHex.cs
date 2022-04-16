using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Board.Components
{
    public interface IHex
    {
        public int Value;
        public ResourceEnum Resource;
    }
}
