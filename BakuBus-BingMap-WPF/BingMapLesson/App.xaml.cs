using BingMapLesson.ViewModels.WindowViewModels;
using BingMapLesson.Views.Windows;
using System.Windows;

namespace BingMapLesson;

public partial class App : Application
{
    private void Main(object sender, StartupEventArgs e)
    {
        var mainWindowView = new MainWindowView();
        mainWindowView.DataContext = new MainWindowViewModel();
        mainWindowView.ShowDialog();

    }
}