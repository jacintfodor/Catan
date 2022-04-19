using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;

namespace Catan.Model.Context.Titles
{
    public class LongestRoadOwner : ITitle
    {
        public IPlayer Owner { get; private set; }

        private LongestRoadOwner() { Owner = NotPlayer.Instance; }

        private static readonly LongestRoadOwner _instance = new();
        public static LongestRoadOwner Instance
        { get { return _instance; } }

        public void ProcessOwner(IPlayer titleContester)
        {
            if (titleContester.LengthOfLongestRoad > Owner.LengthOfLongestRoad)
            {
                Owner = titleContester;
            }
        }

        public int Score { get { return 2; } }
    }
}
