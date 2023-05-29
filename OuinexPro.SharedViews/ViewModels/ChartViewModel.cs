using StockPlot.Charts.Controls;

namespace OuinexPro.SharedViews.ViewModels
{
    public class ChartViewModel
    {
        public StockChart Chart { get; set; } = new StockChart()
        {
            PricesModel = new StockPlot.Charts.Models.StockPricesModel(true),
            DisplayPrice= StockPlot.Charts.DisplayPrice.OHLC
        };
    }
}
