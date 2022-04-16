namespace Catan.Model.Board.Components
{
    public interface IHex
    {
        public int Value {get;set;}
        public ResourceEnum Resource { get; set; }
    }
}
