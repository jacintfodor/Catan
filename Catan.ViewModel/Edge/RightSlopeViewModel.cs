namespace Catan.ViewModel
{ 
    public class RightSlopeViewModel : ViewModelBase
    {
        public RightSlopeViewModel(int row, int column, string owner)
        {
            Row = row;
            Column = column;
            Owner = owner;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public string Owner { get; set; }
    }
}
