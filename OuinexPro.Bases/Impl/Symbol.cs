using OuinexPro.Bases.Interfaces;

namespace OuinexPro.Bases.Impl
{
    public class Symbol : ISymbol
    {
        public Symbol(string exchangeName, string baseC, string quoteC, decimal tcikSize, IPublicExchange exchange)
        {
            ExchangeName= exchangeName;
            BaseCurrency= baseC;
            QuoteCurrency= quoteC;
            NormalizedName = $"{baseC.ToUpper()}/{quoteC.ToUpper()}";
            TickSize = tcikSize;
            Exchange = exchange;
        }

        public string ExchangeName { get; private set; }

        public string BaseCurrency { get; private set; }

        public string QuoteCurrency { get; private set; }

        public string NormalizedName { get; private set; }

        public decimal TickSize { get; private set; }

        public IPublicExchange Exchange { get; private set; }
    }
}
