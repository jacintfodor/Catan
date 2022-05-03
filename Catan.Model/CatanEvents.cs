using Catan.Model.Board.Components;
using Catan.Model.Context;
using Catan.Model.Enums;
using Catan.Model.Events;

namespace Catan.Model
{
    public class CatanEvents
    {
        private CatanEvents()
        {
        }

        private static readonly CatanEvents _instance = new();
        public static CatanEvents Instance
        { get { return _instance; } }

        public event EventHandler<DicesThrownEventArg> DicesThrown;
        public event EventHandler<GameStartEventArgs> GameStart;
        public event EventHandler<PlayerEventArgs> Player;

        public event EventHandler<SettlementBuildingStartedEventArgs> SettlementBuildingStarted;
        public event EventHandler<SettlementBuiltEventArgs> SettlementBuilt;

        public event EventHandler<SettlementUpgradingStartedEventArgs> SettlementUpgradingStarted;
        public event EventHandler<SettlementUpgradedEventArgs> SettlementUpgraded;

        public event EventHandler<RoadBuildingStartedEventArgs> RoadBuildingStarted;
        public event EventHandler<RoadBuiltEventArgs> RoadBuilt;

        public event EventHandler<CancelEventArgs> Cancel;

        public event EventHandler<EventArgs> RogueMovingStarted;
        public event EventHandler<RogueMovedEventArgs> RogueMoved;

        public void OnRogueMovingStarted()
        {
            RogueMovingStarted?.Invoke(this, EventArgs.Empty);
        }

        public void  OnRogueMoved(int row, int col)
        {
            RogueMoved?.Invoke(this, new RogueMovedEventArgs(row, col));
        }

        public void OnRoadBuildingStarted(List<IEdge> edges)
        {
            RoadBuildingStarted?.Invoke(this, new RoadBuildingStartedEventArgs(edges));
        }

        public void OnSettlementBuildingStarted(List<IVertex> vertices)
        {
            SettlementBuildingStarted?.Invoke(this, new SettlementBuildingStartedEventArgs(vertices));
        }

        public void OnSettlementUpgradingStarted(List<IVertex> vertices)
        {
            SettlementUpgradingStarted?.Invoke(this, new SettlementUpgradingStartedEventArgs(vertices));
        }

        public void OnGameStart(CatanContext ctx)
        {
            List<IHex> Hexes = new List<IHex>();
            List<IVertex> Vertices = new List<IVertex>();
            List<IEdge> Edges = new List<IEdge>();

            foreach (IHex hex in ctx.Board.GetHexesEnumerable())
            {
                Hexes.Add(hex);
            }

            foreach (IVertex vertex in ctx.Board.GetVerticesEnumerable())
            {
                Vertices.Add(vertex);
            }

            foreach (IEdge edge in ctx.Board.GetEdgesEnumerable())
            {
                Edges.Add(edge);
            }

            GameStart?.Invoke(this, new GameStartEventArgs(Hexes, Vertices, Edges, Context.Rogue.Instance.Row, Context.Rogue.Instance.Col));
        }

        internal void OnCancel()
        {
            Cancel?.Invoke(this, new CancelEventArgs());
        }

        public void OnDiceThrown(CatanContext ctx)
        {
            DicesThrown?.Invoke(
                this,
                new DicesThrownEventArg(ctx.FirstDice.RolledValue,
                                         ctx.SecondDice.RolledValue
            ));
        }

        public void OnPlayer(CatanContext ctx)
        {
            List<IPlayer> a = new List<IPlayer>();

            Player?.Invoke(
                this,
                new PlayerEventArgs(ctx.GetPlayerList())
                );
        }

        public void OnSettlementBuilt(CatanContext ctx, int row, int col, PlayerEnum player)
        {
            SettlementBuilt?.Invoke(
                this,
                new SettlementBuiltEventArgs(row,col,player)
                );
        }

        public void OnRoadBuilt(CatanContext ctx, int row, int col, PlayerEnum player)
        {
            RoadBuilt?.Invoke(
                this,
                new RoadBuiltEventArgs(row,col,player)
                );
        }

        public void OnSettlementUpgraded(CatanContext ctx, int row, int col)
        {
            SettlementUpgraded?.Invoke(
                this,
                new SettlementUpgradedEventArgs(row, col)
                );
        }
    }
}
