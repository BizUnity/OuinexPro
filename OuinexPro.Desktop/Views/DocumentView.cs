using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace OuinexPro.Desktop.Views
{
    public partial class DocumentView : UserControl
    {
        private ContentControl CustomContent { get; set; }
        public DocumentView() : base()
        {
            CustomContent = new();
            CustomContent.Bind(ContentControl.ContentProperty, new Binding("CustomContent"));
            Content = CustomContent;
        }
    }
}

