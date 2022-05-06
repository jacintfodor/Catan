using Catan.Model.Enums;
using Catan.Model.GameStates;
using Catan.Model.GameStates.ConcreteStates;

namespace Catan.Model.Board.Components
{
    public interface ICommunity
    {
        /// <summary>
        /// Gets the owner of the community.
        /// In case no player owns it, it gets NotPlayer
        /// </summary>
        public PlayerEnum Owner { get; }

        /// <summary>
        /// Gets the type of the community
        /// </summary>
        public CommunityEnum Type { get; }

        /// <summary>
        /// Gets whether the community is upgradable to Town
        /// </summary>
        public bool IsUpgradeable { get; }

        /// <summary>
        /// Adds player to potential builders if applicable.
        /// </summary>
        /// <param name="player">The enum that identifies the player</param>
        /// <exception cref="ArgumentException">Thrown if player is Invalid</exception>
        public void AddPotentionalBuilder(PlayerEnum player);

        /// <summary>
        /// Queries whether player can build the Community.
        /// </summary>
        /// <param name="state">The state the game is currently in.</param>
        /// <param name="player">The enum that identifies the player.></param>
        /// <returns>True if the player can build, otherwise false</returns>
        /// <remarks>
        ///     The game Catan can be separated into 2 different phases where the building logic is different.
        ///     The said phases are
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Early phase</term>
        ///             <description>In the Early phase the player can build any BuildableCommunity</description>
        ///         </item>
        ///         <item>
        ///             <term>Main phase</term>
        ///             <description>In the Main phase the player can build BuildableCommunity,
        ///                 which cannot have any neghbouring built community.
        ///                 As well as it must be connected by roads the player owns to other Built Community the said player owns.</description>
        ///         </item>
        ///     </list>
        ///     Those phases are separated into different states.
        ///     The Early states this logic is concerned about are: (Early phase)
        ///     <list type="bullet">
        ///         <item>
        ///             <term><see cref="EarlyRollingState"/></term>
        ///         </item>
        ///         <item>
        ///             <term><see cref="EarlyRoadBuildingState"/></term>
        ///         </item>
        ///         <item>
        ///             <term><see cref="EarlySettlementBuildingState"/></term>
        ///         </item>
        ///     </list>
        ///     On all the other states the logic assumes Main phase behaviour as default
        /// </remarks>
        public bool IsBuildableByPlayer(ICatanGameState state, PlayerEnum player);
    }
}
