using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model
{
    public class LargestArmyHolder : Title
    {
        public string owner = "";

        public int score() {
            return 2;
        }

        //Iter trough players and the one with the most bones cards wins
        public void processOwner() {
            //acessing players from gamemodel
            /*int max = 0;
            for (Player p in players)
            {
              if (max < p.numberOfHorseCards && 3 < p.numberOfHorseCards){
                max = p.numberOfHorseCards
                owner = p.getName()
              }
            }*/
            owner = "to be implemented";
        }
    }
}
