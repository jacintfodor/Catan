using Catan.Model.Context;

namespace Catan.Model
{
    public class Edge
    {
        public Edge(IPlayer owner)
        {
            Owner = owner;
        }


        //is there is owner there is road
        public IPlayer Owner { get; set; }

        //Crop, Ore, Wood, Brick, Wool
        public Goods Cost { get => new Goods( new List<int>() {0,0,1,1,0 }); }
    }
}