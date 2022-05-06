namespace Catan.ViewModel.Edge
{
    public abstract class BuildableEdgeViewModel : ViewModelBase
    {
        public abstract int Column { get; set; }
        public abstract int Row { get; set; }
        public abstract DelegateCommand BuildCommand { get; set; }
    }
}
