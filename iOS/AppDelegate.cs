using System;

using Foundation;

using InternalLibrary.Services;
using InternalLibrary.ViewModels;

using Softeq.XToolkit.WhiteLabel.Bootstrapper;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Softeq.XToolkit.WhiteLabel.iOS;
using Softeq.XToolkit.WhiteLabel.Navigation;

using UIKit;

namespace InternalLibrary.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : AppDelegateBase
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            // Override point for customization after application launch.

            return result;
        }

        protected override IBootstrapper CreateBootstrapper()
        {
            return new CustomIosBootstrapper();
        }

        protected override void InitializeNavigation(IContainer container)
        {
            var navigationService = container.Resolve<IPageNavigationService>();
            navigationService.Initialize(Window.RootViewController!);
            navigationService.For<BookListViewModel>().Navigate();
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            var uri_netfx = new Uri(url.AbsoluteString);

            _container.Resolve<IGoogleAuthenticator>().OnPageLoading(uri_netfx);

            return true;
        }
    }
}

