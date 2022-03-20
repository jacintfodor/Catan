using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Context.Titles;
using Catan.Model.Context.Players;
using Catan.Model.Board;

namespace Catan.Model
{
    public class CatanContext
    {
        private Queue<IPlayer> _players;

        private CatanContext()
        {
            Board = new();
            FirstDice = new(150);
            LastDice = new(51231);

            throw new NotImplementedException("ControlledPlayer");
        }

        private static readonly CatanContext _instance = new();
        public static CatanContext Instance
        { get { return _instance; } }
        public CatanBoard Board { get; private set; }
        public CubeDice FirstDice { get; private set; }
        public CubeDice LastDice { get; private set; }
        public static LargestArmyHolder LargestArmyHolder { get => LargestArmyHolder.Instance;}
        public static LongestRoadOwner LongestRoadOwner { get => LongestRoadOwner.Instance;}
        public IPlayer CurrentPlayer { get => _players.ElementAtOrDefault(0) ?? NotPlayer.Instance;}
        public IPlayer NextPlayer { get => _players.ElementAtOrDefault(1) ?? NotPlayer.Instance; }
        public IPlayer NextNextPlayer { get => _players.ElementAtOrDefault(2) ?? NotPlayer.Instance; }

        public void EndTurn() { _players.Enqueue( _players.Dequeue()); }
    }
}
