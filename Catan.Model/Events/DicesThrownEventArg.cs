using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;

namespace Catan.Model.Events
{
    public class DicesThrownEventArg : EventArgs
    {
        public int FirstDice { get; private set; }
        public int SecondDice { get; private set; }


        //Crop, Ore, Wood, Brick, Wool
        public int CropCount { get; private set; }
        public int OreCount { get; private set; }
        public int WoodCount { get; private set; }
        public int BrickCount { get; private set; }
        public int WoolCount { get; private set; }

        public DicesThrownEventArg(int a, int b, Goods g)
        {
            FirstDice = a;
            SecondDice = b;

            CropCount = g.Crop;
            OreCount = g.Ore;
            WoodCount = g.Wood;
            BrickCount = g.Brick;
            WoolCount = g.Wool;
        }
    }
}
