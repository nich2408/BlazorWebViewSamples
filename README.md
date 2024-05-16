![image](https://github.com/nich2408/BlazorWebViewSamples/assets/98348348/1498fe3c-c8b4-4ec6-a2f2-fdc066eefd4d)


## 🌐 Blazor WebView samples
In this repository you can find samples on how to use Blazor within a webiew.

### 📁 Included samples
#### ✉ Messages sample
- `webview-messages-sample` contains an example for transmitting messages from a WPF webview to a Blazor app.
##### ✉ Contents
- `BlazorAppSample` contains the Blazor app project to access from the webview.
- `WpfAppSample` contains the WPF project hosting the webview.

##### ✉ Usage
- Open the `.sln` with Visual Studio and start the projects
- Use the `WPF` application to send messages to the `Blazor` app and viceversa
  ![image](https://github.com/nich2408/BlazorWebViewSamples/assets/98348348/905713de-ccf9-4dc8-b12f-9a2eeea026ee)
- Explore the code to find out how to use webview messages API in your projects

### ❔ Other info
- The projects were created using `dotnet-8` with Visual Studio 2022 Community Edition
- WebView2 JS documentation: https://learn.microsoft.com/en-us/microsoft-edge/webview2/reference/javascript/webview
- WebView2 C# documentation: https://learn.microsoft.com/en-us/microsoft-edge/webview2/get-started/wpf#step-10---communication-between-host-and-web-content
- Blazor logo and dotnet bot are property of Microsoft https://www.microsoft.com/
