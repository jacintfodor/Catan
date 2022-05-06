namespace Catan.Model.Context
{
    public class Rogue : IRogue
    {
        public int Row { get; set; }
        public int Col { get; set; }
        private Rogue() { }
        private static readonly Rogue _instance = new();
        public static Rogue Instance
        { get { return _instance; } }

        public void Move(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
