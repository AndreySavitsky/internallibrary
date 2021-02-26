using Android.App;
using Android.OS;
using Android.Webkit;

using InternalLibrary.ViewModels;

using Softeq.XToolkit.WhiteLabel.Droid;

namespace InternalLibrary.Droid.Views
{
    [Activity(Theme = "@style/AppTheme")]
    public class WebPageActivity : ActivityBase<WebViewModel>
    {
        private WebView? _webview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Title = ViewModel.Book.Title;

            SetContentView(Resource.Layout.web_page);

            _webview = FindViewById<WebView>(Resource.Id.webview);
            _webview.Settings.JavaScriptEnabled = true;
            _webview.SetWebViewClient(new WebViewClient());
            _webview.LoadUrl(ViewModel.Book.URL);
        }
    }
}
