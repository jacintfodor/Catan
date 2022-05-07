namespace Catan.Model.GameStates.Interfaces
{
    internal interface ICancellable
    {
        public void Cancel(ICatanContext context);
    }
}
