using Kanadeiar.Core;
using Kanadeiar.Core.Encoders;

namespace WpfAppTest
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void ButtonTestEncrypt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var text = TextBoxTo.Text;
            var result = CaesarEncoder.Encode(text);
            TextBoxFrom.Text = result;
        }

        private void ButtonTextDecrypt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var text = TextBoxFrom.Text;
            var result = CaesarEncoder.Decode(text);
            TextBoxReturn.Text = result;
        }
    }
}
