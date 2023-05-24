using Binance.Net.Clients;
using CryptoExchange.Net.CommonObjects;
using OuinexPro.Bases.Impl;
using OuinexPro.Bases.Interfaces;
using System.Globalization;
using System.Text.Json;

namespace OuinexPro.Exchanges.PublicExchanges
{
    public class PublicBinance : IPublicExchange
    {
        private List<ISymbol> _symbols = new List<ISymbol>();
        private BinanceClient _binanceClient = new BinanceClient();
        private BinanceSocketClient socketClient = new BinanceSocketClient();

        #region impl
        public string ExchangeName => "Binance";

        public bool ProvideSpot => true;

        public bool ProvideFutures => true;

        public bool ProvideMargin => true;

        public bool ProvideOption => false;

        public IEnumerable<ISymbol> Symbols => _symbols;

        public  Task<IRequest<IOHLCs>> GetHistoryAsync(ISymbol symbol, DateTime? start, DateTime? end, bool streamLive, int max)
        {
            return null;
        }

        public async Task<IRequest<ITicker>> GetTickerAsync(ISymbol symbol)
        {
            try
            {
                var t = await _binanceClient.SpotApi.ExchangeData.GetTickerAsync(symbol.ExchangeName);

                var ticker = new Bases.Impl.Ticker();
                ticker.Exchange = this;
                ticker.LastBidPrice = t.Data.BestBidPrice;
                ticker.LastAskPrice = t.Data.BestAskPrice;
                ticker.High = t.Data.HighPrice;
                ticker.Low = t.Data.LowPrice;
                ticker.Spread = ticker.LastAskPrice - ticker.LastBidPrice;

                ticker.RaiseTick();

                var subscribeResult = await socketClient.SpotApi.ExchangeData.SubscribeToTickerUpdatesAsync(symbol.ExchangeName, (t) =>
                {
                    ticker.LastBidPrice = t.Data.BestBidPrice;
                    ticker.LastAskPrice = t.Data.BestAskPrice;
                    ticker.High = t.Data.HighPrice;
                    ticker.Low = t.Data.LowPrice;
                    ticker.Spread = ticker.LastAskPrice - ticker.LastBidPrice;

                    ticker.RaiseTick();
                });

                return new Request<ITicker>(ticker, true);
            }
            catch(Exception ex)
            {
                return new Request<ITicker>(null, false, ex.Message);
            }
        }

        public async Task<IRequest<bool>> InitAsync()
        {
            string url = "https://api.binance.com/api/v3/exchangeInfo";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;

                        using (JsonDocument doc = JsonDocument.Parse(responseString))
                        {
                            JsonElement root = doc.RootElement;
                            JsonElement symbols = root.GetProperty("symbols");

                            foreach (JsonElement element in symbols.EnumerateArray())
                            {
                                var symbol = new Bases.Impl.Symbol(element.GetProperty("symbol").GetString(),
                                    element.GetProperty("baseAsset").GetString(),
                                    element.GetProperty("quoteAsset").GetString(),
                                     decimal.Parse(element.GetProperty("filters")[0].GetProperty("tickSize")!.GetString(), CultureInfo.InvariantCulture),
                                     this);
                                //  symbol.Status = element.GetProperty("status").GetString();
                                //symbol.MinPrice = decimal.Parse( element.GetProperty("filters")[0].GetProperty("minPrice")!.GetString(), CultureInfo.InvariantCulture);
                                //symbol.MaxPrice = decimal.Parse(element.GetProperty("filters")[0].GetProperty("maxPrice")!.GetString(), CultureInfo.InvariantCulture);
                                //symbol.MinQty = decimal.Parse(element.GetProperty("filters")[1].GetProperty("minQty")!.GetString(), CultureInfo.InvariantCulture);
                                // symbol.MaxQty = decimal.Parse(element.GetProperty("filters")[1].GetProperty("maxQty")!.GetString(), CultureInfo.InvariantCulture);
                                // symbol.StepSize = decimal.Parse(element.GetProperty("filters")[1].GetProperty("stepSize")!.GetString(), CultureInfo.InvariantCulture);
                                // symbol.MinNotional = decimal.Parse(element.GetProperty("filters")[2].GetProperty("minNotional")!.GetString(), CultureInfo.InvariantCulture);
                                // symbol.IsSpotTradingAllowed = element.GetProperty("isSpotTradingAllowed").GetBoolean();
                                // symbol.IsMarginTradingAllowed = element.GetProperty("isMarginTradingAllowed").GetBoolean();

                                _symbols.Add(symbol);
                                _symbols.Sort();
                            }
                        }

                        return new Request<bool>(true, true);
                    }
                    else
                    {
                        return new Request<bool>(false, false, $"Error getting response from Binance API : {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    return new Request<bool>(false, false, $"Error getting response from Binance API : {ex.Message}");
                }
            }
        }
        #endregion

    }
}
