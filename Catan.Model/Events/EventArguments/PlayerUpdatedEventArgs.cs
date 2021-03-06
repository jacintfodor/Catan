using Catan.Model.DTOs;

namespace Catan.Model.Events.EventArguments
{
    public class PlayerUpdatedEventArgs : EventArgs
    {
        public List<PlayerDTO> Players { get; private set; }

        public PlayerUpdatedEventArgs(List<PlayerDTO> p)
        {
            Players = p;
        }

    }
}
