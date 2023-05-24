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
            wnd.Show();
        }

        public ICommand LoginCommand { get; }
    }
}
