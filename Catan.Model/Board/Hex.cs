using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model
{
    public class Hex
    {
        public ResourceEnum Resource { get; set; }
        public int Number { get; set; }
        public Hex(ResourceEnum resource, int number)
        {
            Resource = resource;
            Number = number;
        }

    }
}
