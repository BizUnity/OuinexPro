using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using OuinexPro.Bases.Interfaces;
using OuinexPro.ViewModels;

namespace OuinexPro.SharedViews.Views;

public partial class GridMarketWatch : UserControl, IViewComponent
{
    public GridMarketWatch()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public string DisplayName { get; } = "Market Watch";

    private void SearchBox_OnDropDownClosed(object? sender, EventArgs e)
    {
        switch (sender)
        {
            case null:
                return;
            case AutoCompleteBox { SelectedItem: not null } search:
                (DataContext as MarketWatchViewModel)!.AddTicker((ISymbol)search.SelectedItem); 
            
                search.SelectedItem = null;
                break;
        }
    }
}