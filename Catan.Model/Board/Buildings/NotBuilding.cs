using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Board.Buildings
{
    public class NotBuilding : IBuilding
    {
        private NotBuilding()
        {
        }

        private static readonly NotBuilding _instance = new NotBuilding();
        public static NotBuilding Instance
        { get { return _instance; } }

        public int score() { return 0; }
        public int amount() { return 0; }
        public List<int> buildCost() { return new List<int> { 0, 0, 0, 0, 0 }; }
    }
}
