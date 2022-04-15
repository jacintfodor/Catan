using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void OnGameStart(CatanContext ctx)
        {
            GameStart?.Invoke(this, new GameStartEventArgs(ctx.Board.Hexes, ctx.Board.Vertices, ctx.Board.Edges));
        }
    }
}
