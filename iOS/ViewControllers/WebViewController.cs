using System;
using Foundation;
using InternalLibrary.ViewModels;
using Softeq.XToolkit.WhiteLabel.iOS;
using WebKit;

namespace InternalLibrary.iOS.ViewControllers
{
    public partial class WebViewController : ViewControllerBase<WebViewModel>
    {
        public WebViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var url = new NSUrl(ViewModel.URL);
            var request = new NSUrlRequest(url);
            WebView.LoadRequest(request);
        }
    }
}

