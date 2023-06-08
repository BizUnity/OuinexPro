using ReactiveUI;
using System.Windows.Input;
using Dock.Model.Controls;
using Dock.Model.Core;
using OuinexPro.Bases.Interfaces;
using OuinexPro.Desktop.Views;
using OuinexPro.SharedViews;
using OuinexPro.SharedViews.Views;

namespace OuinexPro.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IFactory factory, IDocumentDock dock)
        {
            Factory = factory;
            Dock = dock;

            OpenChartCommand = ReactiveCommand.Create(() =>
            {
              AddDocument(new NewDockTemplate());
            });

            OpenGridMarketWatch = ReactiveCommand.Create(() =>
            {
                AddDocument(new GridMarketWatch());
            });
        }

        public ICommand OpenChartCommand { get; }
        
        public ICommand OpenGridMarketWatch { get; }
        private IDocumentDock Dock { get; }

        private IFactory Factory { get; }

        private void AddDocument(object content)
        {
            DocumentViewModel document = new(content)
            {
                Title = (content is IViewComponent ? (content as IViewComponent)?.DisplayName : "") ?? "New Document",
                CanFloat = true,
                CanPin = true,
                CanClose = true,
            };

            this.Factory?.AddDockable(this.Dock, document);
            this.Factory?.SetActiveDockable(document);
        }
    }
}