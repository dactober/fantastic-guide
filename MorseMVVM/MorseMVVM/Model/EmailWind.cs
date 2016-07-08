//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MorseLibrary;
//using System.Windows;
//using MorseMVVM.Services;
//using MorseMVVM.ViewModel;
//using MorseMVVM.View;

//namespace MorseMVVM.Model
//{
//   public class EmailWind
//    {
//            IMailMessageService _mlmsgsrv;
//            EmailWindowViewModel evm;
//            public EmailWind()
//            {
//                _mlmsgsrv = new MailMessageService();
//                evm = new EmailWindowViewModel(_mlmsgsrv);
//            Window win = new EmailWindowView();
//            win.Show();
//            win.DataContext = evm;
//        }

//            //public Window Create()
//            //{
//            //    return win;
//            //}
//        }

//    }