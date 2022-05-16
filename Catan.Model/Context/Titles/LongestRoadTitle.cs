using Catan.Model.Context.Players;

namespace Catan.Model.Context.Titles
{
    public class LongestRoadTitle : ITitle
    {
        public IPlayer Owner { get; private set; }

        private LongestRoadTitle() { Owner = NotPlayer.Instance; }

        private static readonly ITitle _instance = new LongestRoadTitle();
        public static ITitle Instance
        { get { return _instance; } }

        public void ProcessOwner(IPlayer titleContester)
        {
            if (titleContester.LengthOfLongestRoad > Owner.LengthOfLongestRoad)
            {
                Owner = titleContester;
            }
        }
        public void Reset()
        {
            Owner = NotPlayer.Instance;
        }

        public int Score { get { return 2; } }
    }
}
