using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.PostWebMessageAsString(txbMsg.Text);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            webView.CoreWebView2.Reload();
        }
    }
}