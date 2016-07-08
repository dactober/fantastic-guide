using MorseMVVM.View;
using MorseMVVM.ViewModel;
using System.Windows;

namespace MorseMVVM.Services
{
    public class EmailWindowViewService : IEmailWindowViewService
    {
        public void CreateEmailWindowView(string MessageMorse, string Topic)
        {
            IMailMessageService _mlmsgsrv;
            EmailWindowViewModel evm;

            _mlmsgsrv = new MailMessageService();
            evm = new EmailWindowViewModel(_mlmsgsrv, MessageMorse, "Morse");
            Window win = new EmailWindowView();
            win.Show();
            win.DataContext = evm;
        }
    }
}