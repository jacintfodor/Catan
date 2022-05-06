using Catan.Model.Board.Components;
using Catan.Model.Context;
using Catan.Model.DTOs;
using Catan.Model.Enums;
using Catan.Model.Events.Eventargs;

namespace Catan.Model.Events
{
    public class CatanEvents : ICatanEvents
    {
        private CatanEvents()
        {
        }

        private static readonly ICatanEvents _instance = new CatanEvents();
        internal static ICatanEvents Instance
        { get { return _instance; } }

        public event EventHandler<DicesRolledEventArg> DicesRolled;
        public event EventHandler<GameStartedEventArgs> GameStarted;
        public event EventHandler<PlayerUpdatedEventArgs> PlayerUpdated;

        public event EventHandler<SettlementBuildingStartedEventArgs> SettlementBuildingStarted;
        public event EventHandler<SettlementBuiltEventArgs> SettlementBuilt;

        public event EventHandler<SettlementUpgradingStartedEventArgs> SettlementUpgradingStarted;
        public event EventHandler<SettlementUpgradedEventArgs> SettlementUpgraded;

        public event EventHandler<RoadBuildingStartedEventArgs> RoadBuildingStarted;
        public event EventHandler<RoadBuiltEventArgs> RoadBuilt;

        public event EventHandler<CancelEventArgs> Cancelled;

        public event EventHandler<EventArgs> RogueMovingStarted;
        public event EventHandler<RogueMovedEventArgs> RogueMoved;

        public void OnRogueMovingStarted()
        {
            RogueMovingStarted?.Invoke(this, EventArgs.Empty);
        }

        public void OnRogueMoved(int row, int col)
        {
            RogueMoved?.Invoke(this, new RogueMovedEventArgs(row, col));
        }

        public void OnRoadBuildingStarted(List<EdgeDTO> edges)
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

        public void OnGameStarted(ICatanContext ctx)
        {
            List<HexDTO> Hexes = new List<HexDTO>();
            List<VertexDTO> Vertices = new List<VertexDTO>();
            List<EdgeDTO> Edges = new List<EdgeDTO>();


            

            foreach (IHex hex in ctx.Board.GetHexesEnumerable())
            {
                Hexes.Add(Mapping.Mapper.Map<HexDTO>(hex));
            }

            foreach (IVertex vertex in ctx.Board.GetVerticesEnumerable())
            {
                Vertices.Add(Mapping.Mapper.Map<VertexDTO>(vertex));
            }

            foreach (IEdge edge in ctx.Board.GetEdgesEnumerable())
            {
                Edges.Add(Mapping.Mapper.Map<EdgeDTO>(edge));
            }

            GameStarted?.Invoke(this, new GameStartedEventArgs(Hexes, Vertices, Edges, Context.Rogue.Instance.Row, Context.Rogue.Instance.Col));
        }

        public void OnCancelled()
        {
            Cancelled?.Invoke(this, new CancelEventArgs());
        }

        public void OnDicesRolled(ICatanContext ctx)
        {
            DicesRolled?.Invoke(
                this,
                new DicesRolledEventArg(ctx.FirstDice.RolledValue,
                                         ctx.SecondDice.RolledValue
            ));
        }

        public void OnPlayerUpdated(ICatanContext ctx)
        {
            List<IPlayer> a = new List<IPlayer>();

            PlayerUpdated?.Invoke(
                this,
                new PlayerUpdatedEventArgs(ctx.GetPlayerList())
                );
        }

        public void OnSettlementBuilt(ICatanContext ctx, int row, int col, PlayerEnum player)
        {
            SettlementBuilt?.Invoke(
                this,
                new SettlementBuiltEventArgs(row, col, player)
                );
        }

        public void OnRoadBuilt(ICatanContext ctx, int row, int col, PlayerEnum player)
        {
            RoadBuilt?.Invoke(
                this,
                new RoadBuiltEventArgs(row, col, player)
                );
        }

        public void OnSettlementUpgraded(ICatanContext ctx, int row, int col)
        {
            SettlementUpgraded?.Invoke(
                this,
                new SettlementUpgradedEventArgs(row, col)
                );
        }
    }
}
