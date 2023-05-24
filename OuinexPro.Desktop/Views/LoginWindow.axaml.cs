using Avalonia.Controls;

namespace OuinexPro.Desktop.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            var btn = this.Find<Button>("cancelBTN");
            btn!.Click += (s, e) =>
            {
                Close();
            };
        }
    }
}
