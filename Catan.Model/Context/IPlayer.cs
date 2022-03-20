using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context
{
    public interface IPlayer
    {
        public int CalculateScore();

        public int LengthOfLongestRoad();

        public int sizeOfArmy();

        public Goods AvailableResources { get; set; }

    }
}
