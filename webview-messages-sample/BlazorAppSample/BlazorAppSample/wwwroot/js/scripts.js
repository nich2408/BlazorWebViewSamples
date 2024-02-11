var webViewMessageHelperRef;

// Initializes the webview events.
function initializeWebViewEvents() {
    // See https://learn.microsoft.com/en-us/microsoft-edge/webview2/get-started/wpf#step-10---communication-between-host-and-web-content
    // and https://learn.microsoft.com/en-us/microsoft-edge/webview2/reference/javascript/webview
    // This API is available only when accessing the Blazor app from a webiew. If for any reason this is not available, as alternative you can use direct JS functions instead of messages, see https://learn.microsoft.com/en-us/microsoft-edge/webview2/get-started/wpf#step-9---scripting
    if (window.chrome.webview) {
        window.chrome.webview.addEventListener('message', receiveMessageFromWebView);
    }
}

// Initializes the helper reference required to interop with dotnet.
function initializeDotNetMessagesHelper(helperRef) {
    webViewMessageHelperRef = helperRef;
    console.log("[interop] Initialized messages helper");
}

// Sends the message to the webview.
function sendMessageToWebView(message) {
    // This API is available only when accessing the Blazor app from a webiew. If for any reason this is not available, as alternative you can use direct JS functions instead of messages, see https://learn.microsoft.com/en-us/microsoft-edge/webview2/get-started/wpf#step-9---scripting
    if (window.chrome.webview) {
        window.chrome.webview.postMessage(message);
    }
}

// This one is invoked by the webview that is accessing the Blazor app.
function receiveMessageFromWebView(e) {
    console.log(e);
    // Invoke the method stored in dotnet runtime.
    webViewMessageHelperRef.invokeMethodAsync('PropagateMessageFromWebViewAsync', e.data)
        .then(result => {
            console.log("[interop] Invoked PropagateMessageFromWebViewAsync, result:" + result);
        });
}

// This one should be implemented to dispose the helper object reference.
//window.disposeDotNetHostMessaggeHelper = () => {
//    webViewMessageHelperRef.dispose();
//    console.log("[interop] disposed messagefromhost helper");
//}
