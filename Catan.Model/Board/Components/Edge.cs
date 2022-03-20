using Catan.Model.Board.Buildings;
using Catan.Model.Context;

namespace Catan.Model.Board.Compontents
{
    public class Edge
    {

        public Edge(IPlayer owner, IBuilding building)
        {
            Owner = owner;
            Building = building;
        }

        public IPlayer Owner { get; set; }
        public IBuilding Building { get; set; }
    }
}