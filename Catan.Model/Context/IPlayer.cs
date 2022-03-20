﻿using Catan.Model.Board;

namespace Catan.Model.Context
{
    public interface IPlayer
    {
        public void addResource(ResourceEnum resourceToAdd, int amount);

        public void reduceResources(List<int> resourcesToReduce);

        public int CalculateScore();

        public int LengthOfLongestRoad();

        public int sizeOfArmy();

        public List<int> resources { get; set; }

    }
}
