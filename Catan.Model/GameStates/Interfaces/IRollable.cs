using Catan.Model.GameStates;

namespace Catan.Model.GameStates.Interfaces
{
    internal interface IRollable
    {
        public void RollDices(ICatanContext context);
    }
}
