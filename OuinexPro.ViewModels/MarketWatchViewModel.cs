using System.Collections.ObjectModel;
using Avalonia.Threading;
using OuinexPro.Bases.Interfaces;
using OuinexPro.Exchanges;
using ReactiveUI;

namespace OuinexPro.ViewModels
{
    public class MarketWatchViewModel : ReactiveObject
    {
        public MarketWatchViewModel()
        {
        }
        public ObservableCollection<ISymbol> Symbols { get; } = new(ExchangesContext.AllSymbols);

        public ObservableCollection<TickerViewModel> Tickers { get; } = new();

        public void AddTicker(ISymbol symbol)
        {
            Task.Run(async () =>
            {
                var request = await symbol.Exchange.GetTickerAsync(symbol);
                if (request.Success)
                    await Dispatcher.UIThread.InvokeAsync(() => Tickers.Add(new TickerViewModel(request.Result)));
            });
        }
    }
}