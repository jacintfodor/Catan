using Catan.Model.Context;

namespace Catan.Model
{
    public static class Constants
    {
        //Crop Ore Wood Brick Wool
        public static readonly Goods BonusCardCost =   new Goods(new List<int> { 1, 1, 0, 0, 1 });
        public static readonly Goods SettlementCost=   new Goods(new List<int> { 1, 0, 1, 1, 1 });
        public static readonly Goods TownCost      =   new Goods(new List<int> { 3, 3, 0, 0, 0 });
        public static readonly Goods RoadCost      =   new Goods(new List<int> { 0, 0, 1, 0, 1 });
    }
}
