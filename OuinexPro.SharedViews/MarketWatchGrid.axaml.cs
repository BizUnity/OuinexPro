using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OuinexPro.SharedViews
{
    public partial class MarketWatchGrid : UserControl
    {
        public MarketWatchGrid()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
