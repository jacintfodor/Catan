namespace Catan.Model.GameStates.Interfaces
{
    public interface IRogueMovable
    {
        public void MoveRogue(ICatanContext context, int row, int col);
    }
}
