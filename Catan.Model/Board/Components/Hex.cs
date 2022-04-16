namespace Catan.Model.Board.Components
{
    public class Hex : IHex
    {
        public Hex(ResourceEnum resource, int number = 7)
        {
            Resource = resource;
            Value = number;
        }
        public ResourceEnum Resource { get; set; }
        public int Value { get; set; }
    }
}
