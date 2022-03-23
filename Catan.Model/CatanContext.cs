using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Context.Titles;
using Catan.Model.Context.Players;
using Catan.Model.Board;
using Catan.Model.Events;

namespace Catan.Model
{
    public class CatanContext
    {
        private Queue<IPlayer> _players;

        private CatanContext()
        {
            _players = new();
            init();
        }

        private static readonly CatanContext _instance = new();
        public static CatanContext Instance
        { get { return _instance; } }
        public CatanBoard Board { get; private set; }
        public CubeDice FirstDice { get; private set; }
        public CubeDice SecondDice { get; private set; }
        
        public int RolledSum { get => FirstDice.RolledValue + SecondDice.RolledValue; }

        public static LargestArmyHolder LargestArmyHolder { get => LargestArmyHolder.Instance;}
        public static LongestRoadOwner LongestRoadOwner { get => LongestRoadOwner.Instance;}
        public IPlayer CurrentPlayer { get => _players.ElementAtOrDefault(0) ?? NotPlayer.Instance;}
        public IPlayer NextPlayer { get => _players.ElementAtOrDefault(1) ?? NotPlayer.Instance; }
        public IPlayer NextNextPlayer { get => _players.ElementAtOrDefault(2) ?? NotPlayer.Instance; }
        public IPlayer Winner { get => CurrentPlayer.CalculateScore() >= 5 ? CurrentPlayer : NotPlayer.Instance;  }
        public void EndTurn() { _players.Enqueue( _players.Dequeue()); }

        public void init()
        {
            Board = new();
            FirstDice = new(150);
            SecondDice = new(51231);

            _players.Enqueue(new Player("P1"));
            _players.Enqueue(new Player("P2"));
            _players.Enqueue(new Player("P3"));

            CurrentPlayer.AddResource(new Goods(new List<int> { 1, 1, 1, 1, 1 }));
            NextPlayer.AddResource(new Goods(new List<int> { 2, 2, 2, 2, 2 }));
            NextNextPlayer.AddResource(new Goods(new List<int> { 3, 3, 3, 3, 3 }));

            generateBuildings();
        }

        private void generateBuildings()
        {
            var rnd = new Random();
            var rnd2 = new Random(123424);

            List<int> rows = new List<int>() {1, 1, 1, 1, 3, 3, 3, 5, 5, 2, 2, 2, 2, 4, 4};
            List<int> cols = new List<int>() {3, 5, 6, 7, 1, 5, 8, 4, 6, 2, 5, 6, 7, 4, 5};

            for( int i = 0; i < rows.Count; ++i)
            {
                bool build = rnd.Next(100) > 60;
                
                bool isTown = rnd2.Next(100) > 80;
                if (build)
                {
                    if (isTown)
                        Board.buildTown(rows[i], cols[i], CurrentPlayer);
                    else
                        Board.buildSettlement(rows[i], cols[i], CurrentPlayer);
                }

            }
            
        }

        public void clear()
        {
            _players.Clear();
        }

        public void reset()
        {
            clear();
            init();
        }
    }
}
