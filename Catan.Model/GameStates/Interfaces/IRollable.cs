using Catan.Model.GameStates;

namespace Catan.Model.GameStates.Interfaces
{
    public interface IRollable
    {
        /// <summary>
        /// Roll the dices with context
        /// </summary>
        /// <param name="context"></param>
        public void RollDices(ICatanContext context);
    }
}
