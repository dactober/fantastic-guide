using MailKit;
using MailKit.Net.Imap;
using MorseMVVM.Properties;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;

namespace MorseMVVM.Services
{
    internal class MailMessageService : IMailMessageService
    {
        public void SendMail(string mailto, string caption, string message)
        {
            var smtpServer = Resources.SMTP;
            var from = Resources.MyMail;
            var password = Resources.MyPassword;
            var login = Resources.Login;
            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;

                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 25;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(login, password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.SendAsync(from, mailto, caption, message, this);
            }
        }

        public ObservableCollection<string> GetMail()
        {
            var message = new ObservableCollection<string>();
            using (var client = new ImapClient())
            {
                client.Connect("imap.mail.ru", 993, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate("intego12@mail.ru", "virgo12");

                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                for (int i = 0; i < inbox.Count; i++)
                {
                    var mess = inbox.GetMessage(i);

                    if (mess.Subject == "Morse")
                        message.Add(mess.TextBody);
                }

                client.Disconnect(true);
            }

            return message;
        }
    }
}