using System.Collections.ObjectModel;

namespace MorseMVVM.Services
{
    public interface IMailMessageService
    {
        void SendMail(string mailto,
                       string caption,
                        string message
                       );

        ObservableCollection<string> GetMail();
    }
}