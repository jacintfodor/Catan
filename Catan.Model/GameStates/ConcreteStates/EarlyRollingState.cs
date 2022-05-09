using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.GameStates.Interfaces;

namespace Catan.Model.GameStates.ConcreteStates
{
    public class EarlyRollingState : ICatanGameState, IRollable
    {
        private int _rollCount = 0;
        private readonly Dictionary<PlayerEnum, int> _rolls = new();

        public bool IsEarlyRollingState => true;

        public void RollDices(ICatanContext context)
        {
            
            ++_rollCount;
            context.FirstDice.roll();
            context.SecondDice.roll();
            _rolls.Add(context.CurrentPlayer.ID, context.RolledSum);
            context.NextPlayer();
            context.Events.OnPlayerUpdated(context);
            context.Events.OnDicesRolled(context);
            if (_rollCount == 3)
            {
                int turnsNeededToReachLuckyPlayer = (int)_rolls.First(x => x.Value == _rolls.Values.Max()).Key;
                for (int i = 0; i < turnsNeededToReachLuckyPlayer; i++)
                    context.NextPlayer();

                List<VertexDTO> list =
                    context.Board.GetBuildableSettlementsByPlayer(this, context.CurrentPlayer.ID)
                    .Select(v => Mapping.Mapper.Map<VertexDTO>(v))
                    .ToList();
                context.Events.OnSettlementBuildingStarted(list);
                context.Events.OnPlayerUpdated(context);
                context.SetContext(new EarlySettlementBuildingState(0));
            }
        }
    }
}
