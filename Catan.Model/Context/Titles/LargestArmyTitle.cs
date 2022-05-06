using Catan.Model.Context.Players;

namespace Catan.Model.Context.Titles
{
    public class LargestArmyTitle : ITitle
    {
        public IPlayer Owner { get; private set; }

        private LargestArmyTitle() { Owner = NotPlayer.Instance; }

        private static readonly ITitle _instance = new LargestArmyTitle();
        public static ITitle Instance
        { get { return _instance; } }

        public void ProcessOwner(IPlayer titleContester)
        {
            if (titleContester.KnightCardCount > Owner.KnightCardCount)
            {
                Owner = titleContester;
            }
        }
        public int Score { get { return 2; } }
    }
}
