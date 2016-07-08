using MorseMVVM.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfDialogsTest.BaseClasses;

namespace MorseMVVM.ViewModel

{
    public class MainWindowsViewModel : BaseModel, IDataErrorInfo
    {
        private IDataExchangeService _dataexchangeservice;
        private IMessageBoxService _msgbxsrv;
        private IMailMessageService _mlmsgsrv;
        private IEmailWindowViewService _ewvs;
        private IConvertMorseToSound _cnvmts;

        public MainWindowsViewModel()
        {
        }

        public MainWindowsViewModel(IDataExchangeService dataexchangeservice, IMessageBoxService messageboxservice, IMailMessageService mailmessageservice, IEmailWindowViewService ewvs
            , IConvertMorseToSound cnvmts)
        {
            _dataexchangeservice = dataexchangeservice;
            _msgbxsrv = messageboxservice;
            _mlmsgsrv = mailmessageservice;
            _ewvs = ewvs;
            _cnvmts = cnvmts;
        }

        private string _messagetext;

        public string MessageText
        {
            get { return _messagetext; }
            set
            {
                if (_messagetext != value)
                {
                    _messagetext = value;
                    RaisePropertyChanged("MessageText");
                }
            }
        }

        private string _mailtext;

        public string MailText
        {
            get { return _mailtext; }
            set
            {
                if (_mailtext != value)
                {
                    _mailtext = value;
                    RaisePropertyChanged("MailText");
                }
            }
        }

        private string _messagemorse;

        public string MessageMorse
        {
            get { return _messagemorse; }
            set
            {
                if (_messagemorse != value)
                {
                    _messagemorse = value;
                    RaisePropertyChanged("MessageMorse");
                }
            }
        }

        private ObservableCollection<string> _emailmessage;

        public ObservableCollection<string> EmailMessage
        {
            get { return _emailmessage; }
            set
            {
                if (_emailmessage != value)
                {
                    _emailmessage = value;
                    RaisePropertyChanged("EmailMessage");
                }
            }
        }

        private bool _texttomorse;

        public bool TextToMorse
        {
            get { return _texttomorse; }
            set
            {
                if (_texttomorse != value)
                {
                    _texttomorse = value;
                    RaisePropertyChanged("TextToMorse");
                }
            }
        }

        private ICommand _convert;

        public ICommand Convert
        {
            get { return _convert ?? (_convert = new RelayCommand(ConvertTo)); }
        }

        private ICommand _send;

        public ICommand Send
        {
            get { return _send ?? (_send = new RelayCommand(SendTo)); }
        }

        private ICommand _getemailmessage;

        public ICommand GetEmailMessage
        {
            get { return _getemailmessage ?? (_getemailmessage = new RelayCommand(Getmail)); }
        }

        private void SendTo()
        {
            _ewvs.CreateEmailWindowView(MessageMorse, "Morse");
        }

        private void Getmail()
        {
            EmailMessage = _mlmsgsrv.GetMail();
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                string result = String.Empty;
                if (propertyName == "TextToMorse")
                {
                    if (TextToMorse) { MessageMorse = ""; MessageText = "Can't be empty"; }
                    else { MessageText = ""; MessageMorse = "Can't be empty"; }
                }
                if (propertyName == "MessageText")
                {
                    if (TextToMorse)
                    {
                        MessageMorse = "";
                        if (string.IsNullOrEmpty(MessageText))
                        {
                            result = "Can't be empty";
                        }
                        else
                        {
                            for (int i = 0; i < MessageText.Length; i++)
                            {
                                if ((int)MessageText[i] < 32 || (int)MessageText[i] > 63 && (int)MessageText[i] < 192
                                    || MessageText[i] == 'ё' || MessageText[i] == '#')
                                    result = "Wrong symbol";
                            }
                        }
                    }
                }

                if (propertyName == "MessageMorse")
                {
                    if (!TextToMorse)
                    {
                        MessageText = "";
                        if (string.IsNullOrEmpty(MessageMorse))
                        {
                            result = "Can't be empty";
                        }
                        else
                        {
                            for (int i = 0; i < MessageMorse.Length; i++)
                            {
                                if (MessageMorse[i] != '.' && MessageMorse[i] != '-' && MessageMorse[i] != ' ')
                                {
                                    result = "Wrong symbol";
                                    break;
                                }
                            }
                        }
                    }
                }
                return result;
            }
        }

        private void ConvertTo()
        {
            try
            {
                if (_texttomorse)
                {
                    MessageMorse = _dataexchangeservice.GetMorseText(MessageText);
                    return;
                }

                MessageText = _dataexchangeservice.GetText(MessageMorse);
            }
            catch (Exception ex)
            {
                _msgbxsrv.Show(ex.Message);
            }
        }

        private void GetMail()
        {
            _mlmsgsrv.GetMail();
        }

        private string _convertmorstsound;

        public string SoundMorse
        {
            get { return _convertmorstsound; }
            set
            {
                if (_convertmorstsound != value)
                {
                    _convertmorstsound = value;
                    RaisePropertyChanged("SoundMorse");
                }
            }
        }

        private ICommand _convmortosnd;

        public ICommand ConvertMorseToSound
        {
            get { return _convmortosnd ?? (_convmortosnd = new RelayCommand(ConvertMorsToSound)); }
        }

        public void ConvertMorsToSound()
        {
            _cnvmts.ConvertToSnd(MessageMorse);
        }
    }
}