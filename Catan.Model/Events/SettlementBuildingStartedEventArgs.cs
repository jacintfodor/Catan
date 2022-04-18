using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class SettlementBuildingStartedEventArgs
    {
        public SettlementBuildingStartedEventArgs(List<IVertex> vertices)
        {
            Vertices = vertices;
        }
        public List<IVertex> Vertices { get; private set; }
    }
}
