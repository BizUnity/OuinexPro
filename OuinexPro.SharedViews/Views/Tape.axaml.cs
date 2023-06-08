using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using OuinexPro.ViewModels;

namespace OuinexPro.SharedViews.Views;

public partial class Tape : UserControl
{
    private ItemsControl _listBox;
    private ItemsControl _listBox2;
    private DispatcherTimer _scrollTimer;
    private double _left = 400;
    private bool _isRunning = false;
    public Tape()
    {
        InitializeComponent();
        _listBox = this.Find<ItemsControl>("listBox");
        _listBox2 = this.Find<ItemsControl>("listBox2");

        DataContext = new TapeViewModel();
        AttachEvents();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private void AttachEvents()
    {
        _listBox.AttachedToVisualTree += ListBox_AttachedToVisualTree!;
        _listBox.DetachedFromVisualTree += ListBox_DetachedFromVisualTree!;
        this.PointerExited += (o, e) => { _scrollTimer.Start(); };

        this.PointerEntered += (o, e) => { _scrollTimer.Stop(); };
        _left = this.Bounds.Width;
    }
    private void ListBox_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
    {
        StartScrollAnimation();
    }

    private void ListBox_DetachedFromVisualTree(object sender, VisualTreeAttachmentEventArgs e)
    {
        StopScrollAnimation();
    }
    private void StartScrollAnimation()
    {
        if(_isRunning)
            return;
        _scrollTimer = new ();
        _scrollTimer.Interval = TimeSpan.FromMilliseconds(20);
        _scrollTimer.Tick += ScrollTimer_Tick!;
        _scrollTimer.Start();
        _isRunning = true;
    }
    private void StopScrollAnimation()
    {
        if(_scrollTimer == null)
            return;
        
        _scrollTimer.Stop();
        _scrollTimer.Tick -= ScrollTimer_Tick!;
        _scrollTimer = null!;
        _isRunning = false;
    }
    
    private void ScrollTimer_Tick(object sender, EventArgs e)
    {
        var bound = _listBox.Bounds.Width;
        var width = this.Bounds.Width;
        _left = _left <= (-bound) ? width + _left : _left - 1.5;
        _listBox2.IsVisible = _left < 0;
        _listBox.Margin = new Thickness(_left, 0, 0, 0);

        if (_listBox2.IsVisible)
        {
            _listBox2.Margin = new Thickness((width) + _left, 0, 0, 0);
        }
    }

    public new bool IsVisible
    {
        get => base.IsVisible;
        set
        {
            base.IsVisible = value;

            if (value)
            {
                StartScrollAnimation();
            }
            else
            {
               StopScrollAnimation();
            }
        }
    }
}