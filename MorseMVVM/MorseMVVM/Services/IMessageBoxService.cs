using System.Windows;

namespace MorseMVVM.Services
{
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string messageBoxText = "Wow",
                                      string caption = "Hey",
                                      MessageBoxButton button = MessageBoxButton.OK,
                                      MessageBoxImage icon = MessageBoxImage.None,
                                      MessageBoxResult defaultResult = MessageBoxResult.None,
                                      MessageBoxOptions options = MessageBoxOptions.None);
    }
}