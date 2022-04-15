using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
