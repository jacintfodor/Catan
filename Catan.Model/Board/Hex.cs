using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;

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
