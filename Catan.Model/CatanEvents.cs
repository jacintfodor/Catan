using Catan.Model.Board.Components;
using Catan.Model.Context;
using Catan.Model.Enums;
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

        

        
    }
}
