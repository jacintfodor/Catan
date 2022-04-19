using Catan.Model.Board.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model.Context
{
    public class Rogue
    {
        public int Row { get; set; }
        public int Col { get; set; }
        private Rogue() { }
        private static readonly Rogue _instance = new();
        public static Rogue Instance
        { get { return _instance; } }

        public void Move(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
