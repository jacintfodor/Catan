using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context.Players
{
    public class NotPlayer : IPlayer
    {
        private NotPlayer()
        {
        }

        private static readonly NotPlayer _instance = new NotPlayer();
        public static NotPlayer Instance
        { get { return _instance; } }

        public Goods AvailableResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CalculateScore()
        {
            return -1;
        }

        public int LengthOfLongestRoad()
        {
            return 4;
        }

        public int sizeOfArmy()
        {
            return 2;
        }
    }
}
