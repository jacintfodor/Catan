using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context
{
    public class CubeDice : ICubeDice
    {
        private int _value;
        Random _randomGenerator;

        public int RolledValue { get => _value; }

        public CubeDice(int seed)
        {
            _randomGenerator = new Random(seed);
            _value = 1;
        }

        public void roll()
        {
            _value = _randomGenerator.Next(1, 7);
        }
    }
}
