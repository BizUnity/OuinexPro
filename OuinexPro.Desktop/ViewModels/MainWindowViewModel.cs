using Dock.Model.Avalonia.Controls;
using OuinexPro.Desktop.Views;
using ReactiveUI;
using System.Windows.Input;

namespace OuinexPro.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            OpenChartCommand = ReactiveCommand.Create(() =>
            {
                var tool = new Tool();
                tool.Content = new NewDockTemplate();
                tool.Title = "chart";

                Dock!.Factory!.AddDockable(Dock, tool);

                Dock.ActiveDockable = tool;
            });
        }

        public ICommand OpenChartCommand { get; }

        public ToolDock Dock { get; set; }
    }
}