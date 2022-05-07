using Catan.Model.Enums;

namespace Catan.ViewModel.Edge
{
    public abstract class EdgeViewModel : ViewModelBase
    {
        public abstract PlayerEnum Owner { get; set; }
        public abstract int Column { get; set; }
        public abstract int Row { get; set; }
    }
}
