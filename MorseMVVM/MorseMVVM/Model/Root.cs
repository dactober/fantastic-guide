using MorseMVVM.Services;
using MorseMVVM.View;
using MorseMVVM.ViewModel;
using System.Windows;

namespace MorseMVVM.Model
{
    public class Root : IRoot
    {
        private IDataExchangeService _dataservice;
        private IMessageBoxService _msgbxsrv;
        private IMailMessageService _mlmsgsrv;
        private IEmailWindowViewService _ewvs;
        private IConvertMorseToSound _cnvmts;
        private MainWindowsViewModel mvm;

        public Root()
        {
            _dataservice = new DataExchangeService();
            _msgbxsrv = new MessageBoxService();
            _mlmsgsrv = new MailMessageService();
            _ewvs = new EmailWindowViewService();
            _cnvmts = new ConvertMorseToSnd();
            mvm = new MainWindowsViewModel(_dataservice, _msgbxsrv, _mlmsgsrv, _ewvs, _cnvmts);
        }

        public Window Create()
        {
            Window win = new MainWindowView();
            win.DataContext = mvm;
            return win;
        }
    }

    public interface IRoot
    {
        Window Create();
    }
}