namespace Catan.Model.GameStates.Interfaces
{
    public interface ICancellable
    {
        /// <summary>
        /// Cancel the process
        /// </summary>
        /// <param name="context"></param>
        public void Cancel(ICatanContext context);
    }
}
