﻿using System;
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

        public void processOwner(IPlayer titleContester)
        {
            if (titleContester.LengthOfLongestRoad() > Owner.LengthOfLongestRoad())
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
