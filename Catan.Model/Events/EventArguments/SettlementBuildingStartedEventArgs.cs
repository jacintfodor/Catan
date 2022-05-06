using Catan.Model.DTOs;

namespace Catan.Model.Events.EventArguments
{
    public class SettlementBuildingStartedEventArgs
    {
        public SettlementBuildingStartedEventArgs(List<VertexDTO> vertices)
        {
            Vertices = vertices;
        }
        public List<VertexDTO> Vertices { get; private set; }
    }
}
