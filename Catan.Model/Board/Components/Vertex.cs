using Catan.Model.Board.Buildings;
using Catan.Model.Context;

namespace Catan.Model.Board.Compontents
{
    public class Vertex
    {
        public Vertex(IPlayer owner, Building building, bool validForBuilding = true)
        {
            Owner = owner;
            Building = building;
            ValidForBuilding = validForBuilding;
            EligablePlayers = new List<IPlayer> { };
        }
        public IPlayer Owner { get; set; }
        public Building Building { get; set; }
        public bool ValidForBuilding { get; set; }
        public List<IPlayer> EligablePlayers { get; set; }

    }
}