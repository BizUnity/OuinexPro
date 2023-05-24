using OuinexPro.Bases.Interfaces;

namespace OuinexPro.Bases.Impl
{
    public class Ticker : ITicker
    {
        public event OnTick OnTickHandler;

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal LastBidPrice { get; set; }

        public decimal LastAskPrice { get; set; }

        public decimal Spread { get; set; }

        public ISymbol Symbol { get; set; }

        public IPublicExchange Exchange { get; set; }         

        public void RaiseTick()
        {
            OnTickHandler?.Invoke();
        }
    }
}
