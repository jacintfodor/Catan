using Catan.Model.Enums;

namespace Catan.Model.Board.Components
{
    public interface IRoad
    {
        /// <summary>
        /// Gets the owner of the road.
        /// If no player owns it, it gets NotPlayer
        /// </summary>
        public PlayerEnum Owner { get; }
        
        /// <summary>
        /// Gets whether the road is buildable
        /// </summary>
        public bool IsBuildable { get; }

        /// <summary>
        /// Adds player to potential builders if applicable.
        /// </summary>
        /// <param name="player"></param>
        /// <exception cref="ArgumentException">Thrown if player is Invalid</exception>
        public void AddPotentialBuilder(PlayerEnum player);

        /// <summary>
        /// Queries whether player can build the Road.
        /// </summary>
        /// <param name="player">The enum that identifies the player.</param>
        /// <returns>True if the player can build, otherwise false</returns>
        public bool IsBuildableByPlayer(PlayerEnum player);
    }
}
