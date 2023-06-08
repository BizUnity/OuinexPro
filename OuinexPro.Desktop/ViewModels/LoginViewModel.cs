using System;
using OuinexPro.Desktop.Views;
using OuinexPro.Exchanges;
using ReactiveUI;
using System.Windows.Input;

namespace OuinexPro.Desktop.ViewModels
{
    public sealed class LoginViewModel : ViewModelBase
    {
        public event EventHandler? OnLogged;
        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.Create(async () =>
            { 
                foreach(var exchange in ExchangesContext.PublicExchanges.Values)
                {
                   var init =  await exchange.InitAsync();
                }
                
                OnOnLogged();
            });

            var wnd = new MainWindow();
            if (wnd.RootDock.Factory != null)
            {
                var model = new MainWindowViewModel(wnd.RootDock.Factory, wnd.MainDock);
                wnd.DataContext = model;
            }

            wnd.Show();
        }

        public ICommand LoginCommand { get; }

        private void OnOnLogged()
        {
            OnLogged?.Invoke(this, EventArgs.Empty);
        }
    }
}
