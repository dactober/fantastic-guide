using MorseMVVM.Model;
using System.Windows;

namespace MorseMVVM
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IRoot root = new Root();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            root.Create().Show();
        }
    }
}