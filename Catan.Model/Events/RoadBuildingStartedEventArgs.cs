using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Catan.Model.Board.Components;

namespace Catan.Model.Events
{
    public class RoadBuildingStartedEventArgs
    {
        public RoadBuildingStartedEventArgs(List<IEdge> edges)
        {
            Edges = edges;
        }
        public List<IEdge> Edges { get; private set; }
    }
}
