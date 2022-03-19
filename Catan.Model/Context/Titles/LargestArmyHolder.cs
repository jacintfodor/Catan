using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context.Players;

namespace Catan.Model.Context.Titles
{
    internal class LargestArmyHolder : ITitle
    {
        public IPlayer Owner { get; private set; }

        private LargestArmyHolder() { Owner = NotPlayer.Instance; }

        private static readonly LargestArmyHolder _instance = new();
        public static LargestArmyHolder Instance
        { get { return _instance; } }

        public void processOwner(IPlayer titleContester)
        {
            if (titleContester.NumberOfKnightsOwned() > Owner.NumberOfKnightsOwned())
            {
                Owner = titleContester;
            }
        }

        public int score()
        {
            return 2;
        }
    }
}
