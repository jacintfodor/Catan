namespace Catan.Model
{
    public class Edge
    {
        public Edge(Player owner)
        {
            Owner = owner;
        }


        //is there is owner there is road
        public Player Owner { get; set; }
    }
}