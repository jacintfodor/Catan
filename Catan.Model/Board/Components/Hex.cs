namespace Catan.Model.Board.Compontents
{
    public class Hex : IHex
    {
        public Hex(ResourceEnum resource, int number = 7)
        {
            Resource = resource;
            Number = number;
        }
        public ResourceEnum Resource { get; set; }
        public int Number { get; set; }
    }
}
