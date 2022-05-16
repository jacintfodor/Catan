using Catan.Model.Enums;

namespace Catan.ViewModel
{
    public class BankConfirmEventArgs : EventArgs
    {
        public ResourceEnum From {get; set;}

        public BankConfirmEventArgs(ResourceEnum from) {  From = from;  }
    }
}