﻿using Catan.Model.Board.Buildings;
using Catan.Model.Context;

namespace Catan.Model.Board.Compontents
{
    public class Vertex
    {
        public Vertex(IPlayer owner, Building building)
        {
            Owner = owner;
            Building = building;
        }
        public IPlayer Owner { get; set; }
        public Building Building { get; set; }
    }
}