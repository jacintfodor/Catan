
namespace Catan.ViewModel
{
    public class VerticalViewModel :ViewModelBase
    {
        public VerticalViewModel(int row, int column, string owner)
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
