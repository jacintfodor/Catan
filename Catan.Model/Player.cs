using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Catan.Model
{
    public class Player
    {
        public int[] resources;//enum can be converted to int and vica versa, indexes will equel converted resource int
        private int numberOfSettlemensOwned;
        private int numberOfTownsOwned;
        private int numberOfScoreCardsOwned;
        private int numberOfHorseCardsOwned;
        private int numberOfRoadCarsOwned;
        private int numberOfSettlementCardsOwned;
        private int numberOfTownCradsOwned;

        private String name;

        public Player(String name) {
            this.name = name;
            //fancy way to get max value of enum.
            //(int)Enum.GetValues(typeof(ResourceEnum)).Cast<ResourceEnum>().Max() 
            resources = new int[5];
        }

        public String getName() { return name; }
        public int getScore() {
            
            int retVal = 0;
            retVal += numberOfSettlemensOwned;
            retVal += numberOfTownsOwned;
            //no ref yet
            //retVal += name == LargestArmyHolder.owner ? LargestArmyHolder.score() : 0;
            //retVal += name == LongestRoadOwner.owner ? LongestRoadOwner.score() : 0;
            
            return retVal;

        }
    
    
    }
}
