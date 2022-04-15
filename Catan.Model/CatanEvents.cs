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

        public string Name { get; set; }

        private static readonly CatanEvents _instance = new();
        public static CatanEvents Instance
        { get { return _instance; } }

        public event EventHandler<DicesThrownEventArg> DicesThrown;
        public event EventHandler<GameStartEventArgs> GameStart;
        public event EventHandler<TransactionsHappenedEventArg> TransactionsHappened;

        public void OnGameStart(CatanContext ctx)
        {
            GameStart?.Invoke(this, new GameStartEventArgs(ctx.Board.Hexes, ctx.Board.Vertices, ctx.Board.Edges));
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
    }
}
