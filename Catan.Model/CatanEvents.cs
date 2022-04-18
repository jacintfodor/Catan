using Catan.Model.Board.Components;
using Catan.Model.Enums;
using Catan.Model.Events;

namespace Catan.Model
{
    public class CatanEvents
    {
        private CatanEvents()
        {
        }

        public string Name { get; set; }

        private static readonly CatanEvents _instance = new();
        public static CatanEvents Instance
        { get { return _instance; } }

        public event EventHandler<DicesThrownEventArg> DicesThrown;
        public event EventHandler<GameStartEventArgs> GameStart;
        public event EventHandler<TransactionsHappenedEventArg> TransactionsHappened;
        public event EventHandler<BuildableByPlayerEventArgs> BuildableByPlayer;
        public event EventHandler<RoadBuiltEventArgs> RoadBuilt;
        public event EventHandler<SettlementBuiltEventArgs> SettlementBuilt;

        public event EventHandler<RoadBuildingStartedEventArgs> RoadBuildingStarted;
        public event EventHandler<SettlementBuildingStartedEventArgs> SettlementBuildingStarted;

        public void OnRoadBuildingStarted(List<IEdge> edges)
        {
            RoadBuildingStarted?.Invoke(this, new RoadBuildingStartedEventArgs(edges));
        }

        public void OnSettlementBuildingStarted(List<IVertex> vertices)
        {
            SettlementBuildingStarted?.Invoke(this, new SettlementBuildingStartedEventArgs(vertices));
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

            GameStart?.Invoke(this, new GameStartEventArgs(Hexes, Vertices, Edges));
        }

        public void OnDiceThrown(CatanContext ctx)
        {
            DicesThrown?.Invoke(
                this,
                new DicesThrownEventArg(ctx.FirstDice.RolledValue,
                                         ctx.SecondDice.RolledValue
            ));
        }

        public void OnTransactionsHappened(CatanContext ctx)
        {
            TransactionsHappened?.Invoke(
                this,
                new TransactionsHappenedEventArg(ctx.CurrentPlayer.AvailableResources)
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

        public void OnBuildableByPlayer(CatanContext ctx)
        {
            List<IEdge> edges = new List<IEdge>();
            List<IVertex> vertices = new List<IVertex>();
            PlayerEnum currPlayer = ctx.CurrentPlayer.ID;
            foreach(IEdge edge in ctx.Board.GetEdgesEnumerable())
            {
                if (edge.IsBuildableByPlayer(currPlayer))
                    edges.Add(edge);
            }
            foreach (IVertex vertex in ctx.Board.GetVerticesEnumerable())
            {
                if (vertex.IsBuildableByPlayer(currPlayer))
                    vertices.Add(vertex);
            }

            BuildableByPlayer?.Invoke(
                this,
                new BuildableByPlayerEventArgs(vertices,edges)
                );
        }    
    }
}
