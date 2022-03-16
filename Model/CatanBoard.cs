using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model
{

    public class CatanBoard
    {


        private Hex[,] Hexes = new Hex[5, 5];
        private Edge[,] Edges = new Edge[11, 11];
        private Vertex[,] Vertices = new Vertex[11, 11];
        private List<int> numbers =new List<int>{ 2, 12, 3, 3, 4,4,5,5,6,6,7,7,8,8,9,9,10,10,11,11};

        public CatanBoard()
        {
            generateHexMap();
            generateEdgeMap();
            generateVertexMap();
            int ct = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (!(Vertices[i, j] == null))
                        ct++;
                }
            }
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
                        Edges[x[0], x[1]] = new Edge(new Player("temporary"));
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
                        Vertices[x[0], x[1]] = new Vertex();
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
                int num = numbers[rand.Next(0, numbers.Count)];
                Hexes[coord[0], coord[1]] = new Hex(resource, num);
                emptyHexes.Remove(coord);
                numbers.Remove(num);
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
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 0; j++)
                {
                    if (Hexes[i, j] == null || Hexes[i,j].Number != dieValue)
                        continue;

                    int reward = 2 == dieValue || 12 == dieValue ? 2 : 1;
                    
                    getVertexLocation(i, j).ForEach(x =>
                     {
                         if (Vertices[x[0], x[1]].Owner != null && (int)Hexes[i, j].Resource != 6)
                         { 
                             int rewardMult = reward * Vertices[x[0], x[1]].Building.multiplier(); ;
                             Vertices[x[0], x[1]].Owner.resources[(int)Hexes[i, j].Resource] += rewardMult;
                         }
                     });
                }
            }
        }
    }
}
