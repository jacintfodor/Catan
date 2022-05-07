using Catan.Model.Enums;

namespace Catan.Model.Board.Components.Edge
{
    public interface IEdge
    {
        /// <summary>
        /// Gets the player who owns edge.
        /// In case no player Own it, it gets NoPlayer
        /// </summary>
        public PlayerEnum Owner { get; }

        /// <summary>
        /// Gets the Row of edge
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Gets the Column of edge
        /// </summary>
        public int Col { get; }

        /// <summary>
        /// Adds player to potential builders using <see cref="IRoad"/>.
        /// </summary>
        /// <param name="player">The enum that identifies the player.</param>
        public void AddPotentialBuilder(PlayerEnum player);

        /// <summary>
        /// Queries whether player can build the Road using  <see cref="IRoad"/>.
        /// </summary>
        /// <param name="player">The enum that identifies the player.</param>
        /// <returns>True if player can build, otherwise false</returns>
        public bool IsBuildableByPlayer(PlayerEnum player);

        /// <summary>
        /// Builds the road on this edge using <see cref="IRoad"/>
        /// </summary>
        /// <param name="player">The enum that identifies the player.</param>
        /// <exception cref="InvalidOperationException">Thrown if Road was already built</exception>
        public void Build(PlayerEnum player);
    }
}
