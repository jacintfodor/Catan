using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board.Components.Vertex
{
    public interface IVertex
    {
        /// <summary>
        /// Gets the owner of Vertex.
        /// If no one owns it, it gets NotPlayer.
        /// </summary>
        public PlayerEnum Owner { get; }

        /// <summary>
        /// Gets the row of vertex.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Gets the column of vertex.
        /// </summary>
        public int Col { get; }

        /// <summary>
        /// Gets the type of <see cref="ICommunity"/>.
        /// </summary>
        public CommunityEnum Type { get; }

        /// <summary>
        /// Gets whether Vertex's <see cref="ICommunity"/> is upgradeable.
        /// </summary>
        public bool IsUpgradeable { get; }

        /// <summary>
        /// Adds player to potential builders if applicable using <see cref="ICommunity"/>.
        /// </summary>
        /// <param name="player">The enum that identifies the player.</param>
        public void AddPotentialBuilder(PlayerEnum player);

        /// <summary>
        /// Queries whether player can build the Community using <see cref="ICommunity"/>.
        /// </summary>
        /// <param name="state">The <see cref="ICatanGameState"/> the game is currently in.</param>
        /// <param name="player">The enum that identifies the player.</param>
        /// <returns>True if the player can build, otherwise false</returns>
        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player);

        /// <summary>
        /// Builds the Settlement on this Vertex using <see cref="ICommunity"/>.
        /// </summary>
        /// <param name="state">The <see cref="ICatanGameState"/> the game is currently in.</param>
        /// <param name="player">The enum that identifies the player.</param>
        /// <exception cref="InvalidOperationException">Throw upon vertex is not buildable</exception>
        public void BuildSettlement(ICatanGameState state, PlayerEnum player);

        /// <summary>
        /// Upgrades Settlement to Town using <see cref="ICommunity"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown upon not upgradeable community</exception>
        public void UpgradeToTown();

        /// <summary>
        /// mark vertex as NotBuildable using <see cref="ICommunity"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown upon vertex was already built</exception>
        public void SetNotBuildableCommunity();
    }
}
