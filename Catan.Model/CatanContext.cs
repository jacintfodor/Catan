﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Model.Context;
using Catan.Model.Context.Titles;
using Catan.Model.Context.Players;
using Catan.Model.Board;
using Catan.Model.Events;
using Catan.Model.GameStates;

namespace Catan.Model
{
    public class CatanContext
    {
        private Queue<IPlayer> _players = new();

        private CatanContext()
        {
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
            Random rng = new Random();
            FirstDice = new(rng.Next());
            SecondDice = new(rng.Next());

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
            var rnd2 = new Random(rnd.Next());
            var rnd3 = new Random(rnd2.Next());

            IPlayer p = NotPlayer.Instance;

            List<int> rows = new List<int>() {1, 1, 1, 1, 3, 3, 3, 5, 5, 2, 2, 2, 2, 4, 4};
            List<int> cols = new List<int>() {3, 5, 6, 7, 1, 5, 8, 4, 6, 2, 5, 6, 7, 4, 5};

            for( int i = 0; i < rows.Count; ++i)
            {
                int roll = rnd3.Next(100);
                if (roll > 70)
                    p = NextNextPlayer;
                else if (roll > 40)
                    p = NextPlayer;
                else
                    p = CurrentPlayer;


                bool build = rnd.Next(100) > 60;
                
                bool isTown = rnd2.Next(100) > 80;
                if (build)
                {
                    if (isTown)
                        Board.buildTown(rows[i], cols[i], p);
                    else
                        Board.buildSettlement(rows[i], cols[i], p);
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

        //TODO change State to be an instance of EarlyRollingState once we can
        public ICatanGameState State { get; private set; } = new MainState();
    }
}
