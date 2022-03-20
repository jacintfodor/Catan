using Catan.Model.Board.Buildings;
using Catan.Model.Board.Compontents;

using Catan.Model.Context.Players;

namespace Catan.Model.Board
{

    public class CatanBoard
    {


        private Hex[,] Hexes = new Hex[5, 5];
        private Edge[,] Edges = new Edge[11, 11];
        private Vertex[,] Vertices = new Vertex[11, 11];
        private List<int> numbers =new List<int>{2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };

        public CatanBoard()
        {
            generateHexMap();
            generateEdgeMap();
            generateVertexMap();
        }
        private void generateEdgeMap()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Hexes[i, j] == null)
                        continue;
                    getEdgeLocation(i, j).ForEach(x =>
                    {
                        Edges[x[0], x[1]] = new Edge(NotPlayer.Instance,NotBuilding.Instance);
                    });
                }
            }
        }
        private void generateVertexMap()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Hexes[i, j] == null)
                        continue;
                    getVertexLocation(i, j).ForEach(x =>
                    {
                        Vertices[x[0], x[1]] = new Vertex(NotPlayer.Instance,NotBuilding.Instance);
                    });
                }
            }
        }
        private List<int[]> getEmptyHexes()
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
        private void generateHexMap()
        {
            List<int[]> emptyHexes = getEmptyHexes();
            
            generateHexes(4, ResourceEnum.Crop, emptyHexes);
            generateHexes(4, ResourceEnum.Wood, emptyHexes);
            generateHexes(4, ResourceEnum.Wool, emptyHexes);
            generateHexes(3, ResourceEnum.Brick, emptyHexes);
            generateHexes(3, ResourceEnum.Ore, emptyHexes);
            generateHexes(1, ResourceEnum.Desert, emptyHexes);
        }
        private void generateHexes(int amount, ResourceEnum resource, List<int[]> emptyHexes)
        {
            var rand = new Random();

            for (int i = 0; i < amount; i++)
            {
                int[] coord = emptyHexes[rand.Next(0, emptyHexes.Count)];
                if (numbers.Count > 0)
                {
                    int num = numbers[rand.Next(0, numbers.Count)];
                    Hexes[coord[0], coord[1]] = new Hex(resource, num);
                    emptyHexes.Remove(coord);
                    numbers.Remove(num);
                }
                else
                {
                    Hexes[coord[0], coord[1]] = new Hex(resource);
                }
            }
        }

        //Returns a index list of edges to a hex from hex's index
        private List<int[]> getEdgeLocation(int row, int col) {
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
        //Returns a index list of vertices to a hex from hex's index
        private List<int[]> getVertexLocation(int row, int col)
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
        
        public void distributeResource(int dieValue)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (Hexes[row, col] == null || Hexes[row, col].Number != dieValue)
                        continue;

                    getVertexLocation(row, col).ForEach(x =>
                     {
                         if (Vertices[x[0], x[1]].Owner != NotPlayer.Instance)
                         { 
                             int amount = Vertices[x[0], x[1]].Building.amount();
                             Vertices[x[0], x[1]].Owner.addResource(Hexes[row, col].Resource, amount);
                         }
                     });
                }
            }
        }

        //builds a road at given index, doesnt check connection, or if player has enough resource
        public void buildRoad(int row, int col, Player builder)
        {
            if (Edges[row,col] != null && Vertices[row,col].Owner is NotPlayer)
            { 
                Edges[row, col].Owner = builder;
                Edges[row, col].Building = new Road();
                builder.reduceResources(Edges[row, col].Building.buildCost());
            }
        }

        //builds a settlement at given index, doesnt check connection, or if player has enough resource
        public void buildSettlement(int row, int col, Player builder)
        {
            if (Vertices[row, col] != null && Vertices[row, col].Owner is NotPlayer)
            {
                Vertices[row, col].Owner = builder;
                Vertices[row, col].Building = new Settlement();
                builder.reduceResources(Vertices[row, col].Building.buildCost());
            }
        }

        //builds a town at given index, doesnt check connection, or if player has enough resource
        public void buildTown(int row, int col, Player builder)
        {
            if (Vertices[row, col].Building is Settlement && builder == Vertices[row, col].Owner)
            {
                Vertices[row, col].Building = new Town();
                builder.reduceResources(Vertices[row, col].Building.buildCost());
            }
        }
    }
}
