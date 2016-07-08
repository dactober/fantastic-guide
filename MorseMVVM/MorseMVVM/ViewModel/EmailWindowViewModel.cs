using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorseLibrary;
using WpfDialogsTest.BaseClasses;
using MorseMVVM.Services;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Documents;

namespace MorseMVVM.ViewModel
{
    public class EmailWindowViewModel:BaseModel
    {


        IMailMessageService _mlmsgsrv;
        public EmailWindowViewModel(IMailMessageService mailmessageservice,string message,string topic)
        {
            Message = message;
             _mlmsgsrv = mailmessageservice;
            Topic = topic;
             
        }

        string _mailto;
        public string MailTo
        {
            get { return _mailto; }
            set
            {
                if (_mailto != value)
                {
                    _mailto = value;
                    RaisePropertyChanged("MailTo");

                }

            }

        }
        string _topic;

        public string Topic
        {
            get { return _topic; }
            set
            {
                if (_topic != value)
                {
                    _topic = value;
                    RaisePropertyChanged("Topic");

                }

            }

        }

        string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged("Message");

                }

            }

        }

        private ICommand _send;
        public ICommand Send
        {
            get { return _send ?? (_send = new RelayCommand(SendOnEmail)); }
        }



        private void SendOnEmail()
        {
            _mlmsgsrv.SendMail(MailTo, Topic, Message);

        }
        
    }
}
