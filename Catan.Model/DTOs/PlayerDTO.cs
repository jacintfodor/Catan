using Catan.Model.Enums;

namespace Catan.Model.DTOs
{
    public record PlayerDTO
    {
        public PlayerEnum ID { get; init; }
        public GoodsDTO AvailableResources { get; init; }
        public int AvailableSettlementCardCount { get; init; }
        public int AvailableTownCardCount { get; init; }
        public int AvailableRoadCardCount { get; init; }
        public int ScoreCardCount { get; init; }
        public int KnightCardCount { get; init; }
        public int LengthOfLongestRoad { get; init; }
        public int Score { get; init; }
    }
}
