using Microsoft.JSInterop;

namespace BlazorAppSample.Client.Helpers
{
    /// <summary>
    /// Helper class for handling the messages sent from the webiew.
    /// </summary>
    public class WebViewMessaggesHelper
    {
        public event EventHandler<string> MessageReceived;

        /// <summary>
        /// This method will be invoked from Javascript interop when the message sent from the webview is received.
        /// </summary>
        /// <param name="messagge">The message sent from the webview.</param>
        [JSInvokable(nameof(PropagateMessageFromWebViewAsync))]
        public Task<string> PropagateMessageFromWebViewAsync(string? messagge)
        {
            try
            {
                MessageReceived?.Invoke(this, messagge ?? "EMPTY_MESSAGE");
                return Task.FromResult("OK");
            }
            catch (Exception ex)
            {
                return Task.FromResult($"ERR:{ex}");
            }
        }
    }
}
