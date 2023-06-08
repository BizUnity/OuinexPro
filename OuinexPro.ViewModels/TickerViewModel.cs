using OuinexPro.Bases.Interfaces;
using ReactiveUI;

namespace OuinexPro.ViewModels;

public class TickerViewModel : ReactiveObject
{
    private ITicker _ticker;
    private decimal _bid, _ask;
    public TickerViewModel(ITicker ticker)
    {
        _ticker = ticker;
        _bid = _ticker.LastBidPrice;
        _ask = _ticker.LastBidPrice;
            
        _ticker.OnTickHandler += (TickerOnOnTickHandler);
    }

    private void TickerOnOnTickHandler()
    {
        Bid = _ticker.LastBidPrice;
        Ask = _ticker.LastAskPrice;
    }

    public ITicker Ticker => _ticker;

    public decimal Bid
    {
        get => _bid;
        set => this.RaiseAndSetIfChanged(ref _bid, value);
    }

    public decimal Ask
    {
        get => _ask;
        set => this.RaiseAndSetIfChanged(ref _ask, value);
    }
}