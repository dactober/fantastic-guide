using System.Windows;

namespace MorseMVVM.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult Show(string messageBoxText,
                                     string caption,
                                     MessageBoxButton button,
                                     MessageBoxImage icon,
                                     MessageBoxResult defaultResult,
                                     MessageBoxOptions options)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
        }
    }
}