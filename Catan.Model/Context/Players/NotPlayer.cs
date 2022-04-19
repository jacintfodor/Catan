﻿using Catan.Model.Board;
using Catan.Model.Enums;

namespace Catan.Model.Context.Players
{
    public class NotPlayer : IPlayer
    {
        private NotPlayer()
        {
        }

        public PlayerEnum ID { get ; set; }

        private static readonly NotPlayer _instance = new NotPlayer();
        public static NotPlayer Instance
        { get { return _instance; } }

        public Goods AvailableResources { get => new Goods(); set => new Goods();}

        public int AvailableSettlementCardCount => -1;

        public int AvailableTownCardCount => -1;

        public int AvailableRoadCardCount => -1;

        public int ScoreCardCount => -1;

        public int KnightCardCount => -1;

        public int LengthOfLongestRoad { get => -1; set =>
            throw new NotImplementedException(); }

        public int CalculateScore()
        {
            return -1;
        }

        public void AddResource(Goods resourcesToRemove)
        {
            throw new NotImplementedException();
        }

        public void ReduceResources(Goods resourcesToReduce)
        {
            throw new NotImplementedException();

        }
        public bool CanAfford(Goods resourcesToAfford)
        {
            return false;
        }
        public void BuildRoad()
        {
            throw new NotImplementedException();
        }

        public void BuildTown()
        {
            throw new NotImplementedException();
        }

        public void BuildSettlement()
        {
            throw new NotImplementedException();
        }

        public bool CanBuildRoad()
        {
            throw new NotImplementedException();
        }

        public bool CanBuildTown()
        {
            throw new NotImplementedException();
        }

        public bool CanBuildSettlement()
        {
            throw new NotImplementedException();
        }

        public void AddScoreCard()
        {
            throw new NotImplementedException();
        }

        public void AddKnightCard()
        {
            throw new NotImplementedException();
        }
    }
}
