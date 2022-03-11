using Catan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Model

{
    public class Field
    {
        ResourceEnum type;
        private int Communities; //Will store related players 
        private int Value; //Guess dice value?
        public int Roads;

        public bool isRobbed()
        {
            //Robber, get field to be implemented
            return false;
        }

        public ResourceEnum giveResources()
        {
            return type;
        }    
    }
}
