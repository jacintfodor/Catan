using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;

namespace Catan.Model.Context.Titles
{
    public class LargestArmyHolderTitle : ITitle
    {
        public IPlayer Owner { get; private set; }

        private LargestArmyHolderTitle() { Owner = NotPlayer.Instance; }

        private static readonly ITitle _instance = new LargestArmyHolderTitle();
        public static ITitle Instance
        { get { return _instance; } }

        public void ProcessOwner(IPlayer titleContester)
        {
            if (titleContester.KnightCardCount > Owner.KnightCardCount)
            {
                Owner = titleContester;
            }
        }
        public int Score { get { return 2; } }
    }
}
