using Catan.Model.Enums;

namespace Catan.Model.DTOs
{
    public record VertexDTO
    {
        public PlayerEnum? Owner { get; init; }
        public int? Row { get; init; }
        public int? Col { get; init; }
    }
}
