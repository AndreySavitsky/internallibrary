using System;

using Xamarin.Auth;

namespace InternalLibrary.Services
{
    public interface IGoogleAuthenticator
    {
        public OAuth2Authenticator Authenticator { get; }
        public void OnPageLoading(Uri uri);
    }
}
