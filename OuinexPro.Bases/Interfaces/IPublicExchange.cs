namespace OuinexPro.Bases.Interfaces;

public interface IPublicExchange
{
    string ExchangeName { get; }

    bool ProvideSpot { get; }

    bool ProvideFutures { get; }

    bool ProvideMargin { get; }

    bool ProvideOption { get; }

    IEnumerable<ISymbol> Symbols { get; }

    Task<IRequest<ITicker>> GetTickerAsync(ISymbol symbol);

    Task<IRequest<IOHLCs>> GetHistoryAsync(ISymbol symbol, DateTime? start, DateTime? end, bool streamLive, int max);

    Task<IRequest<bool>> InitAsync();
}

