namespace Catan.Model.Events.EventArguments
{
    public class DicesRolledEventArg : EventArgs
    {
        public int FirstDice { get; private set; }
        public int SecondDice { get; private set; }


        

        public DicesRolledEventArg(int a, int b)
        {
            FirstDice = a;
            SecondDice = b;
        }
    }
}
