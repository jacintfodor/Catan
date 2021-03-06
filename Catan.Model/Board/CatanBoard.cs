using Catan.Model.Board.Components.Edge;
using Catan.Model.Board.Components.Hex;
using Catan.Model.Board.Components.Vertex;
using Catan.Model.Enums;
using Catan.Model.GameStates;

namespace Catan.Model.Board
{
    /// <inheritdoc cref="ICatanBoard"/>
    public class CatanBoard : ICatanBoard
    {

        #region Variables
        private IHex[,] _Hexes = new IHex[5, 5];
        private IVertex[,] _Vertices = new IVertex[11, 11];
        private IEdge[,] _Edges = new IEdge[11, 11];
        private List<int> numbers = new List<int> { 2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };
        #endregion Variables

        #region Constructor
        public CatanBoard()
        {
            GenerateHexMap();
            GenerateEdgeMap();
            GenerateVertexMap();
        }
        #endregion Constructor

        #region Board Generation
        private void GenerateEdgeMap()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (_Hexes[i, j] == null)
                        continue;
                    GetEdgeLocationOfHex(i, j).ForEach(x =>
                    {
                        _Edges[x[0], x[1]] = new Edge(x[0], x[1]);
                    });
                }
            }
        }
        private void GenerateVertexMap()
        {
            var rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (_Hexes[i, j] == null)
                        continue;
                    GetVertexLocationsOfHex(i, j).ForEach(x =>
                    {
                        _Vertices[x[0], x[1]] = new Vertex(x[0], x[1]);
                    });
                }
            }
        }
        private List<int[]> GetEmptyHexes()
        {
            List<int[]> retVal = new List<int[]>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 0 && j == 0 || i == 0 && j == 4 || i == 4 && j == 0 || i == 4 && j == 4 || i == 1 && j == 4 || i == 3 && j == 4)
                        continue;
                    retVal.Add(new int[] { i, j });
                }
            }
            return retVal;
        }
        private void GenerateHexMap()
        {
            List<int[]> emptyHexes = GetEmptyHexes();

            GenerateHexes(4, ResourceEnum.Crop, emptyHexes);
            GenerateHexes(4, ResourceEnum.Wood, emptyHexes);
            GenerateHexes(4, ResourceEnum.Wool, emptyHexes);
            GenerateHexes(3, ResourceEnum.Brick, emptyHexes);
            GenerateHexes(3, ResourceEnum.Ore, emptyHexes);
            GenerateHexes(1, ResourceEnum.Desert, emptyHexes);
        }
        private void GenerateHexes(int amount, ResourceEnum resource, List<int[]> emptyHexes)
        {
            var rand = new Random();

            for (int i = 0; i < amount; i++)
            {
                int[] coord = emptyHexes[rand.Next(0, emptyHexes.Count)];
                if (numbers.Count > 0)
                {
                    int num = numbers[rand.Next(0, numbers.Count)];
                    _Hexes[coord[0], coord[1]] = new Hex(resource, coord[0], coord[1], num);
                    emptyHexes.Remove(coord);
                    numbers.Remove(num);
                }
                else
                {
                    _Hexes[coord[0], coord[1]] = new Hex(resource, coord[0], coord[1]);
                }
            }
        }
        private List<int[]> GetEdgeLocationOfHex(int row, int col)
        {
            List<int[]> retVal = new List<int[]>();
            int offset = row % 2;
            offset = 0 - offset;
            retVal.Add(new int[] { 2 * row, 2 * (col - offset) + offset });
            retVal.Add(new int[] { 2 * row, 2 * (col - offset) + 1 + offset });
            retVal.Add(new int[] { 2 * row + 1, 2 * (col - offset) + offset });
            retVal.Add(new int[] { 2 * row + 1, 2 * (col - offset) + 2 + offset });
            retVal.Add(new int[] { 2 * row + 2, 2 * (col - offset) + offset });
            retVal.Add(new int[] { 2 * row + 2, 2 * (col - offset) + 1 + offset });
            return retVal;
        }
        private List<int[]> GetVertexLocationsOfHex(int row, int col)
        {
            List<int[]> retVal = new List<int[]>();
            int offset = row % 2;
            offset = 0 - offset;
            retVal.Add(new int[] { row, 2 * (col - offset) + offset });
            retVal.Add(new int[] { row, 2 * (col - offset) + 1 + offset });
            retVal.Add(new int[] { row, 2 * (col - offset) + 2 + offset });
            retVal.Add(new int[] { row + 1, 2 * (col - offset) + offset });
            retVal.Add(new int[] { row + 1, 2 * (col - offset) + 1 + offset });
            retVal.Add(new int[] { row + 1, 2 * (col - offset) + 2 + offset });
            return retVal;
        }
        #endregion board generation

        #region Geters of board pieces
        public IEdge GetEdge(int row, int col)
        {
            return _Edges[row, col];
        }

        //Returns a list of vertices to a hex from hex's index
        public List<IVertex> GetVerticesOfHex(int row, int col)
        {
            List<IVertex> retVal = new List<IVertex>();
            int offset = row % 2;
            offset = 0 - offset;
            retVal.Add(_Vertices[row, 2 * (col - offset) + offset]);
            retVal.Add(_Vertices[row, 2 * (col - offset) + 1 + offset]);
            retVal.Add(_Vertices[row, 2 * (col - offset) + 2 + offset]);
            retVal.Add(_Vertices[row + 1, 2 * (col - offset) + offset]);
            retVal.Add(_Vertices[row + 1, 2 * (col - offset) + 1 + offset]);
            retVal.Add(_Vertices[row + 1, 2 * (col - offset) + 2 + offset]);
            return retVal;
        }

        //Returns a list of neighbouring Vertices of given Vertex index
        public List<IVertex> GetNeighborVerticesOfVertex(int row, int col)
        {
            List<IVertex> retVal = new List<IVertex>();
            int offset = row % 2 == col % 2 ? 1 : -1;
            if (row + offset >= 0 && row + offset < 11)
            {
                if (_Vertices[row + offset, col] != null)
                    retVal.Add(_Vertices[row + offset, col]);
            }

            if (col + 1 < 11)
            {
                if (_Vertices[row, col + 1] != null)
                    retVal.Add(_Vertices[row, col + 1]);
            }

            if (col - 1 >= 0)
            {
                if (_Vertices[row, col - 1] != null)
                    retVal.Add(_Vertices[row, col - 1]);
            }
            return retVal;
        }
        //Returns a list of neighbouring Edges of given Vertex index
        public List<IEdge> GetNeighborEdgesOfVertex(int row, int col)
        {
            List<IEdge> retVal = new List<IEdge>();
            int offset = row % 2 == col % 2 ? 1 : -1;
            if (col < 11 && row * 2 < 11)
            {

                if (_Edges[row * 2, col] != null)
                    retVal.Add(_Edges[row * 2, col]);
            }
            if (col < 11 && row * 2 + offset < 11 && row * 2 + offset >= 0)
            {
                if (_Edges[row * 2 + offset, col] != null)
                    retVal.Add(_Edges[row * 2 + offset, col]);
            }

            if (col - 1 >= 0 && row * 2 < 11)
            {
                if (_Edges[row * 2, col - 1] != null)
                    retVal.Add(_Edges[row * 2, col - 1]);
            }
            return retVal;
        }
        //Returns a list of end Vertices of given Edge index
        public List<IVertex> GetNeighbourVerticesOfEdge(int row, int col)
        {
            List<IVertex> retVal = new List<IVertex>();
            if (row % 2 == 0)
            {
                if (_Vertices[row / 2, col] != null)
                    retVal.Add(_Vertices[row / 2, col]);
                if (_Vertices[row / 2, col + 1] != null)
                    retVal.Add(_Vertices[row / 2, col + 1]);
            }
            else
            {
                if (_Vertices[(row - 1) / 2, col] != null)
                    retVal.Add(_Vertices[(row - 1) / 2, col]);
                if (_Vertices[(row + 1) / 2, col] != null)
                    retVal.Add(_Vertices[(row + 1) / 2, col]);
            }
            return retVal;
        }

        public List<IEdge> GetEdgesofEdge(int row, int col)
        {
            List<IEdge> retVal = new List<IEdge>();
            List<IVertex> vertices = new List<IVertex>();

            GetNeighbourVerticesOfEdge(row, col).ForEach(vertex =>
            {
                GetNeighborEdgesOfVertex(vertex.Row, vertex.Col).ForEach(edge =>
                {
                    if (!(edge.Row == row && edge.Col == col))
                    {
                        retVal.Add(edge);
                    }
                });
            });
            return retVal;
        }
        #endregion Getters of board pieces

        #region Enumerators
        public IEnumerable<IHex> GetHexesEnumerable()
        {
            for (int row = 0; row < 5; row++)
                for (int col = 0; col < 5; col++)
                {
                    if (_Hexes[row, col] == null)
                        continue;
                    else
                        yield return _Hexes[row, col];
                }
        }
        public IEnumerable<IVertex> GetVerticesEnumerable()
        {
            for (int row = 0; row < 11; row++)
                for (int col = 0; col < 11; col++)
                {
                    if (_Vertices[row, col] == null)
                        continue;
                    else
                        yield return _Vertices[row, col];
                }
        }
        public IEnumerable<IEdge> GetEdgesEnumerable()
        {
            for (int row = 0; row < 11; row++)
                for (int col = 0; col < 11; col++)
                {
                    if (_Edges[row, col] == null)
                        continue;
                    else
                        yield return _Edges[row, col];
                }
        }
        #endregion

        #region Methods 
        public void BuildRoad(int row, int col, PlayerEnum player)
        {
            if (!_Edges[row, col].IsBuildableByPlayer(player)) throw new InvalidOperationException("NotBuildAbleByPlayer");
            _Edges[row, col].Build(player);
            GetNeighbourVerticesOfEdge(row, col)
                .ForEach(v => v.AddPotentialBuilder(player));
            GetEdgesofEdge(row, col)
                .ForEach(e => e.AddPotentialBuilder(player));
        }

        public void BuildSettlement(int row, int col, ICatanGameState state, PlayerEnum player)
        {
            if (!_Vertices[row, col].IsBuildableByPlayer(state, player)) throw new InvalidOperationException("NotBuildAbleByPlayer");
            _Vertices[row, col].BuildSettlement(state, player);
            GetNeighborEdgesOfVertex(row, col)
                .ForEach(e => e.AddPotentialBuilder(player));
            GetNeighborVerticesOfVertex(row, col)
                .ForEach(v => v.SetNotBuildableCommunity());
        }

        public void UpgradeSettlement(int row, int col)
        {
            if (!_Vertices[row, col].IsUpgradeable) throw new InvalidOperationException("NotUpgradable");

            _Vertices[row, col].UpgradeToTown();
        }

        public int CalculateLongestRoadFromEdge(int row, int col, PlayerEnum id)
        {
            int retVal = 0;

            List<IEdge> processed = new List<IEdge>();
            List<IEdge> toProcess = new List<IEdge>();

            toProcess.Add(GetEdge(row, col));
            while (toProcess.Any())
            {
                IEdge currentlyProccessing = toProcess.First();
                toProcess.Remove(currentlyProccessing);
                retVal++;

                GetEdgesofEdge(currentlyProccessing.Row, currentlyProccessing.Col).ForEach(edge =>
                {
                    if (edge.Owner == id && !toProcess.Contains(edge) && !processed.Contains(edge) && edge != currentlyProccessing)
                        toProcess.Add(edge);
                });
                processed.Add(currentlyProccessing);
            }
            return retVal;
        }
        public List<IEdge> GetBuildableRoadsByPlayer(PlayerEnum id)
        {
            List<IEdge> retVal = new List<IEdge>();
            foreach (IEdge edge in GetEdgesEnumerable())
            {
                if (edge.IsBuildableByPlayer(id))
                    retVal.Add(edge);
            }

            return retVal;
        }
        public List<IVertex> GetBuildableSettlementsByPlayer(ICatanGameState state, PlayerEnum id)
        {
            List<IVertex> retVal = new List<IVertex>();
            foreach (IVertex vertex in GetVerticesEnumerable())
            {
                if (vertex.IsBuildableByPlayer(state, id))
                    retVal.Add(vertex);
            }

            return retVal;
        }
        public List<IVertex> GetUpgradeableSettlementsByPlayer(PlayerEnum id)
        {
            List<IVertex> retVal = new List<IVertex>();
            foreach (IVertex vertex in GetVerticesEnumerable())
            {
                if (vertex.Owner == id && vertex.IsUpgradeable)
                    retVal.Add(vertex);
            }

            return retVal;
        }
        #endregion Methods
    }
}
