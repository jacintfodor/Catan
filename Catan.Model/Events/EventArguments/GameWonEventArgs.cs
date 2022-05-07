namespace Catan.Model.Events.EventArguments
{
    public class GameWonEventArgs : EventArgs
    {
        public GameWonEventArgs(int score)
        {
            Score = score;
        }

        public int Score { get; private set; }
    }
}
