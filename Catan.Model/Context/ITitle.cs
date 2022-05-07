namespace Catan.Model.Context
{
    public interface ITitle
    {
        public IPlayer Owner { get; }
        public int Score { get;  }
        public void ProcessOwner(IPlayer titleContester);
    }
}
