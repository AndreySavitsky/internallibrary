using Android.App;
using Android.Content;
using Android.OS;

using InternalLibrary.Services;
using InternalLibrary.ViewModels;

using Softeq.XToolkit.WhiteLabel;
using Softeq.XToolkit.WhiteLabel.Droid;

using System;

using Xamarin.Auth;

namespace InternalLibrary.Droid
{
    [Activity(Label = "GoogleAuthInterceptor")]
    [
        IntentFilter
        (
            actions: new[] { Intent.ActionView },
            Categories = new[]
            {
                    Intent.CategoryDefault,
                    Intent.CategoryBrowsable
            },
            DataSchemes = new[]
            {
                "com.softeq.internallibrary"
            },
            DataPaths = new[]
            {
                "/oauth2redirect"
            }
        )
    ]
    public class GoogleAuthInterceptor : ActivityBase<GoogleAuthInterceptorViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            CustomTabsConfiguration.CustomTabsClosingMessage = null;

            Android.Net.Uri uri_android = Intent.Data;

            Uri uri_netfx = new Uri(uri_android.ToString());

            Dependencies.Container.Resolve<IGoogleAuthenticator>().OnPageLoading(uri_netfx);

            Finish();
        }
    }
}
