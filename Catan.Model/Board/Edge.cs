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
    }
}