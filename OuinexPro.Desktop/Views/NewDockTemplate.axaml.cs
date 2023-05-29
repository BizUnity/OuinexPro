using Avalonia.Controls;
using OuinexPro.SharedViews.ViewModels;
using OuinexPro.SharedViews.Views;
using System.Drawing;

namespace OuinexPro.Desktop.Views
{
    public partial class NewDockTemplate : UserControl
    {
        public NewDockTemplate()
        {
            InitializeComponent();

            var chart = this.Find<Button>("chart");
            var test = this.Find<Button>("btn");

            chart.Click += Chart_Click;
            test.Click += Test_Click;
        }

        private void Test_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Content = new Button() { Content = "hbjj" };
        }

        private void Chart_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Content = new ChartView()
            {
                DataContext = new ChartViewModel()
            };
        }
    }
}
