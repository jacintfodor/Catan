using Catan.Model.Enums;

namespace Catan.ViewModel
{
    public class BankConfirmEventArgs : EventArgs
    {
        public string Message { get; set; }
        public ResourceEnum From {get; set;}
        public ResourceEnum To { get; set; }

        public BankConfirmEventArgs(string s, ResourceEnum from, ResourceEnum to) { Message = s; From = from; To = to; }
    }
}