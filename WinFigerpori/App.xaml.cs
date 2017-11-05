using System.Windows;
using WinFigerpori.Models;

namespace WinFigerpori
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var model = new MainWindowModel();
            var view = new MainWindow { DataContext = model };
            view.ShowDialog();
        }
    }
}
