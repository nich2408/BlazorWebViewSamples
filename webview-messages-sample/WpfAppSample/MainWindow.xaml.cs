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
            _ = InitializeWebViewAsync();
        }

        private async Task InitializeWebViewAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            // Handle receiving messages from webview.
            webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
        }

        private void CoreWebView2_WebMessageReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            txbReceivedMsg.Text = e.TryGetWebMessageAsString();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // This example posts a string, you can also post JSON.
            webView.CoreWebView2.PostWebMessageAsString(txbMsg.Text);
        }

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            await this.webView.CoreWebView2.Profile.ClearBrowsingDataAsync();
            webView.CoreWebView2.Reload();
        }
    }
}