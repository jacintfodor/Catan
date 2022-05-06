using Catan.Model.DTOs;

namespace Catan.Model.Events.Eventargs
{
    public class RoadBuildingStartedEventArgs
    {
        public RoadBuildingStartedEventArgs(List<EdgeDTO> edges)
        {
            Edges = edges;
        }
        public List<EdgeDTO> Edges { get; private set; }
    }
}
