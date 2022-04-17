namespace Catan.Model.Board.Components
{
    public class Hex : IHex
    {
        public Hex(ResourceEnum resource, int row, int col, int number = 7)
        {
            Resource = resource;
            Value = number;
            Row = row;
            Col = col;
        }
        public ResourceEnum Resource { get; set; }
        public int Value { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
