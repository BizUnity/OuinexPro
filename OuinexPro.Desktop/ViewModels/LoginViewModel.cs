using OuinexPro.Desktop.Views;
using OuinexPro.Exchanges;
using ReactiveUI;
using System.Windows.Input;

namespace OuinexPro.Desktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.Create(async () =>
            { 
                foreach(var exchange in ExchangesContext.PublicExchanges.Values)
                {
                   var init =  await exchange.InitAsync();
                }
            });

            var wnd = new MainWindow();
            var model = new MainWindowViewModel();
            model.Dock = wnd.BottomPane;
            wnd.DataContext = model;
            wnd.Show();
        }

        public ICommand LoginCommand { get; }
    }
}
