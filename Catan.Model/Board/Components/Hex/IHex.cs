using Catan.Model.Enums;

namespace Catan.Model.Board.Components.Hex
{
    public interface IHex
    {
        /// <summary>
        /// The number on the hexagon
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// The Resource of the hexagon
        /// </summary>
        public ResourceEnum Resource { get; set; }
        /// <summary>
        /// The number of the hexagon row
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// The number of the hexagon column
        /// </summary>
        public int Col { get; set; }
    }
}
