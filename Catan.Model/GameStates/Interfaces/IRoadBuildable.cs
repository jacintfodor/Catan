namespace Catan.Model.GameStates
{
    public interface IRoadBuildable
    {
        /// <summary>
        /// Build road with context 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="row">The row to build</param>
        /// <param name="col">the column to bulid</param>
        public void BuildRoad(ICatanContext context, int row, int col);
    }
}
