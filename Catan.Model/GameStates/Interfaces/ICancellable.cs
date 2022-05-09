namespace Catan.Model.GameStates.Interfaces
{
    public interface ICancellable
    {
        public void Cancel(ICatanContext context);
    }
}
