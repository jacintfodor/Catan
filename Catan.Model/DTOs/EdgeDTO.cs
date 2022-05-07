using Catan.Model.Enums;

namespace Catan.Model.DTOs
{
    public record EdgeDTO
    {
        public PlayerEnum Owner { get; init; }
        public int Row { get; init; }
        public int Col { get; init; }
    }
}
