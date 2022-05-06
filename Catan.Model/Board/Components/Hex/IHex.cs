using Catan.Model.Enums;

namespace Catan.Model.Board.Components.Hex
{
    public interface IHex
    {
        public int Value { get; set; }
        public ResourceEnum Resource { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
