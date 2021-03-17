using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace InternalLibrary.Forms.Servsices
{
    public class WebAuthenticatorService : IWebAuthenticatorService
    {
        const string googleAuthenticationUrl = "http://localhost:1898/mobileauth/Google";

        public async Task<WebAuthenticatorResult> OnGoogleAuthenticate()
        {
            WebAuthenticatorResult webAuthenticatorResult = null;

            try
            {
                var authUrl = new Uri(googleAuthenticationUrl);
                var callbackUrl = new Uri("com.softeq.internallibrary://");

                webAuthenticatorResult = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);
            }
            catch (OperationCanceledException)
            {
                await App.Current.MainPage.DisplayAlert(null, "Login canceled.", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(null, $"Failed: {ex.Message}", "Ok");
            }

            return webAuthenticatorResult;
        }
    }
}
