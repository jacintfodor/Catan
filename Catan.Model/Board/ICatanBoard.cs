using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board
{
    public interface ICatanBoard
    {
        /// <summary>
        /// Build <see cref="BuiltRoad"/> on board using <see cref="IEdge"/>.
        /// </summary>
        /// <param name="row">The row to build <see cref="BuiltRoad"/> on.</param>
        /// <param name="col">The column to build <see cref="BuiltRoad"/> on.</param>
        /// <param name="player">The <see cref="PlayerEnum"/> that identifies the player.</param>
        /// <exception cref="InvalidOperationException">Thrown upon player not able to build <see cref="BuiltRoad"/>.</exception>
        /// <remarks>
        /// <list type="bullet">
        ///     <item>
        ///         <term>mark neighbouring edges as buildable by player</term>
        ///         <description>Adds player to potential builder if applicable <see cref="IEdge"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term>mark neighbouring vertices as buildable by player</term>
        ///         <description>Adds player to potential builders if applicable <see cref="IVertex"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        void BuildRoad(int row, int col, PlayerEnum player);

        /// <summary>
        /// Build <see cref="Settlement"/> on board using <see cref="IVertex"/>.
        /// </summary>
        /// <param name="row">The row to build <see cref="Settlement"/> on.</param>
        /// <param name="col">The column to build <see cref="Settlement"/> on.</param>
        /// <param name="state">The <see cref="ICatanGameState"/> the game is currently in.</param>
        /// <param name="player">The <see cref="PlayerEnum"/> that identifies the player.</param>
        /// <exception cref="InvalidOperationException">Thrown upon player not able to build <see cref="Settlement"/>.</exception>
        /// <remarks>
        /// <list type="bullet">
        ///     <item>
        ///         <term>mark neighbouring edges as buildable by player</term>
        ///         <description>Adds player potential builder edges buildable by player if applicable <see cref="IEdge"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term>mark neighbouring vertices as not buildable by any one</term>
        ///         <description>sets vertices to be not buildable if applicable <see cref="IVertex"/>.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        void BuildSettlement(int row, int col, ICatanGameState state, PlayerEnum player);

        /// <summary>
        /// gets <see cref="IEdge"/>.
        /// </summary>
        /// <param name="row">The row of <see cref="IEdge"/>.</param>
        /// <param name="col">The column of <see cref="IEdge"/>.</param>
        /// <returns><see cref="IEdge"/> that matches parameters.</returns>
        IEdge GetEdge(int row, int col);

        /// <summary>
        /// Makes <see cref="IEdge"/> of the board iterable.
        /// </summary>
        /// <returns><see cref="IEnumerable{IEdge}"/> which can iterate through all the valid edges</returns>
        IEnumerable<IEdge> GetEdgesEnumerable();

        /// <summary>
        /// list neighbouring edges of <see cref="IEdge"/> of board.
        /// </summary>
        /// <param name="row">The row of <see cref="IEdge"/> to get neighbours from.</param>
        /// <param name="col">The column of <see cref="IEdge"/> to get neighbours from.</param>
        /// <returns><see cref="List{IEdge}"/> which contains the neighbouring edges of <see cref="IEdge"/>.</returns>
        List<IEdge> GetEdgesofEdge(int row, int col);

        /// <summary>
        /// Makes <see cref="IHex"/> of the board iterable.
        /// </summary>
        /// <returns><see cref="IEnumerable{IHex}"/> which can iterate through all the valid hexes</returns>
        IEnumerable<IHex> GetHexesEnumerable();

        /// <summary>
        /// list neighbouring edges of <see cref="IVertex"/> of board.
        /// </summary>
        /// <param name="row">The row of <see cref="IVertex"/> to get neighbours from.</param>
        /// <param name="col">The column of <see cref="IVertex"/> to get neighbours from.</param>
        /// <returns><see cref="List{IEdge}"/> which contains the neighbouring edges of <see cref="IVertex"/>.</returns>
        List<IEdge> GetNeighborEdgesOfVertex(int row, int col);

        /// <summary>
        /// list neighbouring vertices of <see cref="IVertex"/> of board.
        /// </summary>
        /// <param name="row">The row of <see cref="IVertex"/> to get neighbours from.</param>
        /// <param name="col">The column of <see cref="IVertex"/> to get neighbours from.</param>
        /// <returns><see cref="List{IVertex}"/> which contains the neighbouring vertices of <see cref="IVertex"/>.</returns>
        List<IVertex> GetNeighborVerticesOfVertex(int row, int col);

        /// <summary>
        /// list neighbouring vertices of <see cref="IEdge"/> of board.
        /// </summary>
        /// <param name="row">The row of <see cref="IEdge"/> to get neighbours from.</param>
        /// <param name="col">The column of <see cref="IEdge"/> to get neighbours from.</param>
        /// <returns><see cref="List{IVertex}"/> which contains the neighbouring vertices of <see cref="IEdge"/>.</returns>
        List<IVertex> GetNeighbourVerticesOfEdge(int row, int col);

        /// <summary>
        /// Makes <see cref="IVertex"/> of the board iterable.
        /// </summary>
        /// <returns><see cref="IEnumerable{IVertex}"/> which can iterate through all the valid vertices</returns>
        IEnumerable<IVertex> GetVerticesEnumerable();

        /// <summary>
        /// list neighbouring vertices of <see cref="IHex"/> of board.
        /// </summary>
        /// <param name="row">The row of <see cref="IHex"/> to get neighbours from.</param>
        /// <param name="col">The column of <see cref="IHex"/> to get neighbours from.</param>
        /// <returns><see cref="List{IVertex}"/> which contains the neighbouring vertices of <see cref="IHex"/>.</returns>
        List<IVertex> GetVerticesOfHex(int row, int col);

        /// <summary>
        /// Upgrade <see cref="Settlement"/> to <see cref="Town"/> on board using <see cref="IVertex"/>.
        /// </summary>
        /// <param name="row">The row to upgrade <see cref="Settlement"/> on.</param>
        /// <param name="col">The column to upgrade <see cref="Settlement"/> on.</param>
        /// <param name="player">The <see cref="PlayerEnum"/> that identifies the player.</param>
        /// <exception cref="InvalidOperationException">Thrown upon player not able to upgrade <see cref="Settlement"/>.</exception>
        void UpgradeSettlement(int row, int col);

        /// <summary>
        /// calculates the largest component made of player owned roads.
        /// </summary>
        /// <param name="row">The row to start the calculation from.</param>
        /// <param name="col">The column to start the calculation from.</param>
        /// <param name="id">The <see cref="PlayerEnum"/> that identifies the player.</param>
        /// <returns>The size of the largest component of roads owned by the player</returns>
        int CalculateLongestRoadFromEdge(int row, int col, PlayerEnum id);

        /// <summary>
        /// list buildable <see cref="IEdge"/>s of <paramref name="id"/>.
        /// </summary>
        /// <returns><see cref="List{IEdge}"/> which contains the buildable <see cref="IEdge"/>s of <paramref name="id"/>.</returns>
        List<IEdge> GetBuildableRoadsByPlayer(PlayerEnum id);

        /// <summary>
        /// list buildable <see cref="IVertex"/>es of <paramref name="id"/>.
        /// </summary>
        /// <returns><see cref="List{IVertex}"/> which contains the buildable <see cref="IVertex"/>es of <paramref name="id"/>.</returns>
        List<IVertex> GetBuildableSettlementsByPlayer(ICatanGameState state, PlayerEnum id);

        /// <summary>
        /// list upgradeable <see cref="IVertex"/>es of <paramref name="id"/>.
        /// </summary>
        /// <returns><see cref="List{IVertex}"/> which contains the upgradeable <see cref="IVertex"/>es of <paramref name="id"/>.</returns>
        List<IVertex> GetUpgradeableSettlementsByPlayer(PlayerEnum id);
        
    }
}