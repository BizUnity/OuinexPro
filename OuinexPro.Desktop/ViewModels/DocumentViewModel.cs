using CommunityToolkit.Mvvm.ComponentModel;
using Dock.Model.Mvvm.Controls;

namespace OuinexPro.Desktop.ViewModels;

public partial class DocumentViewModel :Document
{
    [ObservableProperty]
    private object _CustomContent;
    
    public DocumentViewModel(object content) : base()
    {
        CustomContent = content;
    }
}