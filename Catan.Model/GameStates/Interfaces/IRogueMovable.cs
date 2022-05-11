namespace Catan.Model.GameStates.Interfaces
{
    public interface IRogueMovable
    {
        /// <summary>
        /// Move rogue with the context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="row">The row to build </param>
        /// <param name="col">The column to build </param>
        public void MoveRogue(ICatanContext context, int row, int col);
    }
}
