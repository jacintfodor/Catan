namespace Catan.Model.Context
{
    public interface IRogue
    {
        int Col { get; set; }
        int Row { get; set; }

        void Move(int row, int col);
    }
}