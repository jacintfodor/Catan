namespace Catan.Model.DTOs
{
    public record GoodsDTO
    {
        public int Crop { get; init; }
        public int Ore { get; init; }
        public int Wood { get; init; }
        public int Brick { get; init; }
        public int Wool { get; init; }
    }
}
