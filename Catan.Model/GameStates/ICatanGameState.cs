using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Context;
using Catan.Model.Enums;

namespace Catan.Model.GameStates
{
    internal interface ICatanGameState
    {
        
        // TODO IsAffordable does not depend on state remove it, once we dont use it anymore
        public bool IsAffordable(CatanContext context, Goods g) { return false; }


        public bool IsEarlyRollingState => false;
        public bool IsEarlySettlementBuildingState => false;
        public bool IsEarlyRoadBuildingState => false;
        public bool IsRollingState => false;
        public bool IsMainState => false;
        public bool IsSettlementBuildingState => false;
        public bool IsRoadBuildingState => false;
        public bool IsSettlementUpgradingState => false;
        public bool IsWinningState => false;
        public bool IsRogueMovingState => false;
    }
}
