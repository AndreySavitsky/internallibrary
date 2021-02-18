using System;

using Xamarin.Auth;

namespace InternalLibrary.Services
{
    public class GoogleAuthenticator : IGoogleAuthenticator
    {
        private const string AuthorizeUrl = "https://accounts.google.com/o/oauth2/v2/auth";
        private const string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        private const bool IsUsingNativeUI = true;

        private static OAuth2Authenticator _auth;

        public GoogleAuthenticator(IGoogleAPIConfoguration googleAPIConfiguration)
        {
            _auth = new OAuth2Authenticator(googleAPIConfiguration.ClientID,
                string.Empty,
                googleAPIConfiguration.Scope,
                new Uri(AuthorizeUrl),
                new Uri(googleAPIConfiguration.RedirectUrl),
                new Uri(AccessTokenUrl),
                null, IsUsingNativeUI);
        }

        public OAuth2Authenticator Authenticator => _auth;

        public void OnPageLoading(Uri uri)
        {
            _auth.OnPageLoading(uri);
        }
    }
}
