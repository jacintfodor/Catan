using Catan.Model.Context;

namespace Catan.Model
{
    public class Vertex
    {
        public IPlayer Owner { get; set; }

        public Building Building { get; set; }
        public Vertex()
        {}

    }
}