using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;

namespace Catan.Model.Context.Titles
{
    public class LongestRoadOwnerTitle : ITitle
    {
        public IPlayer Owner { get; private set; }

        private LongestRoadOwnerTitle() { Owner = NotPlayer.Instance; }

        private static readonly ITitle _instance = new LongestRoadOwnerTitle();
        public static ITitle Instance
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
