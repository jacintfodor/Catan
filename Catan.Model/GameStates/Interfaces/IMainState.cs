using Catan.Model.Enums;

namespace Catan.Model.GameStates.Interfaces
{
    public interface IMainState
    {
        /// <summary>
        /// End turn and the next player will comes
        /// </summary>
        /// <param name="context"></param>
        public void EndTurn(ICatanContext context);
        /// <summary>
        /// Exchange with the bank 3 to one resource
        /// </summary>
        /// <param name="context"></param>
        /// <param name="from">It will reduce</param>
        /// <param name="to">iIt will decrease</param>
        public void ExchangeWithBank(ICatanContext context, ResourceEnum from, ResourceEnum to);
        /// <summary>
        /// Buy a bonuscard 
        /// </summary>
        /// <param name="context"></param>
        public void PurchaseBonusCard(ICatanContext context);
        /// <summary>
        /// Start building a road
        /// </summary>
        /// <param name="context"></param>
        public void StartRoadBuilding(ICatanContext context);
        /// <summary>
        /// Start building a settlment
        /// </summary>
        /// <param name="context"></param>
        public void StartSettlementBuilding(ICatanContext context);
        /// <summary>
        /// Start uppgrading a settlment to town
        /// </summary>
        /// <param name="context"></param>
        public void StartSettlementUpgrading(ICatanContext context);
    }
}
