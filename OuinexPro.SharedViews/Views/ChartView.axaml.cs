using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OuinexPro.SharedViews.Views;

public partial class ChartView : UserControl
{
    public ChartView()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}