using Catan.Model.Enums;

namespace Catan.Model.DTOs
{
    public record HexDTO
    {
        public int Value { get; init; }
        public ResourceEnum Resource { get; init; }
        public int Row { get; init; }
        public int Col { get; init; }
    }
}
