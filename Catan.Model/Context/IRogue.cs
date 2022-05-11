namespace Catan.Model.Context
{
    public interface IRogue
    {
        /// <summary>
        /// The number of the rogue col
        /// </summary>
        int Col { get; set; }
        /// <summary>
        /// The number of the rogue row
        /// </summary>
        int Row { get; set; }
        /// <summary>
        /// Move to the rouge for the (row;col) position
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        void Move(int row, int col);
    }
}