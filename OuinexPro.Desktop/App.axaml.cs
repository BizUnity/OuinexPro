using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OuinexPro.Desktop.ViewModels;
using OuinexPro.Desktop.Views;

namespace OuinexPro.Desktop
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var dataContext = new LoginViewModel();
                var wnd = new LoginWindow()
                {
                    DataContext = dataContext
                };
                desktop.MainWindow = wnd;

                dataContext.OnLogged += (o,e) =>
                {
                    wnd.Close();
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}