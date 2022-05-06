namespace Catan.Model.GameStates.Interfaces
{
    internal interface IRogueMovable
    {
        public void MoveRogue(ICatanContext context, int row, int col);
    }
}
