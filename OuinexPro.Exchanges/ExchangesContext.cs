using OuinexPro.Bases.Interfaces;
using OuinexPro.Exchanges.PublicExchanges;

namespace OuinexPro.Exchanges
{
    public static class ExchangesContext
    {
        public static Dictionary<string, IPublicExchange> PublicExchanges { get; } = new Dictionary<string, IPublicExchange>()
        {
            { "Binance", new PublicBinance() }
        };

        public static List<ISymbol> AllSymbols { get; } = new();
    }
}