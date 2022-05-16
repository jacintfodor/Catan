namespace Catan.Model.Context
{
    public interface ITitle
    {
        /// <summary>
        /// The owner of this title is
        /// </summary>
        public IPlayer Owner { get; }
        /// <summary>
        /// The extra point for this title
        /// </summary>
        public int Score { get;  }
        /// <summary>
        /// The player who deserves it will earns it
        /// </summary>
        /// <param name="titleContester"></param>
        public void ProcessOwner(IPlayer titleContester);
        public void Reset();
    }
}
