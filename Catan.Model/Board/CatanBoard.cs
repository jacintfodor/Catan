﻿using Catan.Model.Board.Buildings;
using Catan.Model.Board.Compontents;
using Catan.Model.Context;
using Catan.Model.Context.Players;
using Catan.Model.Events;

namespace Catan.Model.Board
{

    public class CatanBoard
    {

        #region Variables
        public Hex[,] Hexes = new Hex[5, 5];
        public Vertex[,] Vertices = new Vertex[11, 11];
        public Edge[,] Edges = new Edge[11, 11];
        private List<int> numbers = new List<int> { 2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };
        #endregion Variables

        #region Constructor
        public CatanBoard()
        {
            generateHexMap();
            generateEdgeMap();
            generateVertexMap();
        }
        #endregion Constructor

        #region Board Generation
        private void generateEdgeMap()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Hexes[i, j] == null)
                        continue;
                    getEdgeLocationOfHex(i, j).ForEach(x =>
                    {
                        Edges[x[0], x[1]] = new Edge(NotPlayer.Instance, NotBuilding.Instance);
                    });
                }
            }
        }
        private void generateVertexMap()
        {
            var rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Hexes[i, j] == null)
                        continue;
                    getVertexLocationsOfHex(i, j).ForEach(x =>
                    {
                       
                        Vertices[x[0], x[1]] = new Vertex(NotPlayer.Instance, NotBuilding.Instance);
                        
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
        private List<int[]> getEdgeLocationOfHex(int row, int col)
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
        private List<int[]> getVertexLocationsOfHex(int row, int col)
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
        //Returns a list of vertices to a hex from hex's index
        public List<Vertex> getVerticesOfHex(int row, int col)
        {
            List<Vertex> retVal = new List<Vertex>();
            int offset = row % 2;
            offset = 0 - offset;
            retVal.Add(Vertices[row, 2 * (col - offset) + offset]);
            retVal.Add(Vertices[row, 2 * (col - offset) + 1 + offset]);
            retVal.Add(Vertices[row, 2 * (col - offset) + 2 + offset]);
            retVal.Add(Vertices[row + 1, 2 * (col - offset) + offset]);
            retVal.Add(Vertices[row + 1, 2 * (col - offset) + 1 + offset]);
            retVal.Add(Vertices[row + 1, 2 * (col - offset) + 2 + offset]);
            return retVal;
        }

        //Returns a list of neighbouring Vertices of given Vertex index
        public List<Vertex> getNeighborVerticesOfVertex(int row, int col)
        {
            List<Vertex> retVal = new List<Vertex>();
            int offset = row % 2 == col % 2 ? -1 : 1;

            if (Vertices[row + offset, col] != null)
                retVal.Add(Vertices[row + offset, col]);

            if (Vertices[row, col + 1] != null)
                retVal.Add(Vertices[row, col + 1]);

            if (Vertices[row, col - 1] != null)
                retVal.Add(Vertices[row, col - 1]);

            return retVal;
        }
        //Returns a list of neighbouring Edges of given Vertex index
        public List<Edge> getNeighborEdgesOfVertex(int row, int col)
        {
            List<Edge> retVal = new List<Edge>();
            int offset = row % 2 == col % 2 ? -1 : 1;
            if (Edges[row * 2 + offset, col] != null)
                retVal.Add(Edges[row * 2 + offset, col]);

            if (Edges[row * 2, col-1] != null)
                retVal.Add(Edges[row * 2, col - 1]);

            if (Edges[row * 2 + offset, col] != null)
                retVal.Add(Edges[row * 2, col]);

            return retVal;
        }
        //Returns a list of end Vertices of given Edge index
        public List<Vertex> getNeighbourVerticesOfEdge(int row, int col)
        {
            List<Vertex> retVal = new List<Vertex>();
            if (row % 2 == 0)
            {
                if(Vertices[row / 2, col] != null)
                    retVal.Add(Vertices[row/2,col]);
                if(Vertices[row / 2, col+1] != null)
                    retVal.Add(Vertices[row/2,col+1]);
            }
            else
            {
                if (Vertices[(row - 1) / 2, col] != null)
                    retVal.Add(Vertices[(row-1) / 2, col]);
                if(Vertices[(row + 1) / 2, col] != null)
                    retVal.Add(Vertices[(row+1) / 2, col]);
            }
            return retVal;
        }
        #endregion Getters of board pieces

        #region Enumerators
        public IEnumerable<Hex> GetHexesEnumerable()
        {
            for(int row = 0; row < 5; row++)
                for (int col = 0; col < 5; col++)
                {
                    if (Hexes[row, col] == null)
                        continue;
                    else
                        yield return Hexes[row, col];
                }
        }

        public IEnumerable<Vertex> GetVerticesEnumerable()
        {
            for (int row = 0; row < 11; row++)
                for (int col = 0; col < 11; col++)
                {
                    if (Vertices[row, col] == null)
                        continue;
                    else
                        yield return Vertices[row, col];
                }
        }
        #endregion

        #region Methods 
        public void distributeResource(int dieValue)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (Hexes[row, col] == null || Hexes[row, col].Number != dieValue)
                        continue;

                    getVerticesOfHex(row, col).ForEach(vertex =>
                     {
                         if (vertex.Owner != NotPlayer.Instance)
                         { 
                             int amount = vertex.Building.amount();
                             vertex.Owner.AddResource(new Goods(Hexes[row,col].Resource) * amount);
                         }
                     });
                }
            }
        }

        public void buildRoad(int row, int col, IPlayer builder)
        {
            Edges[row, col].Owner = builder;
            Edges[row, col].Building = new Road();
        }

        public void buildSettlement(int row, int col, IPlayer builder)
        {
            Vertices[row, col].Owner = builder;
            Vertices[row, col].Building = new Settlement();
        }

        public void buildTown(int row, int col)
        {
            Vertices[row, col].Building = new Town();

        }

        public void buildTown(int row, int col, IPlayer builder)
        {
            Vertices[row, col].Owner = builder;
            Vertices[row, col].Building = new Town();

        }
        #endregion Methods
    }
}
