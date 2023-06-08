using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;

namespace OuinexPro.Desktop.Views
{
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.RootDock.DefaultDockable = this.MainDock;
        }
    }  
}