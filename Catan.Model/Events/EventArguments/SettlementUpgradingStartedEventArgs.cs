using Catan.Model.DTOs;

namespace Catan.Model.Events.EventArguments
{
    public class SettlementUpgradingStartedEventArgs : EventArgs
    {
        public SettlementUpgradingStartedEventArgs(List<VertexDTO> vertices)
        {
            Vertices = vertices;
        }
        public List<VertexDTO> Vertices { get; private set; }
    }
}
