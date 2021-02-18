using Google.Apis.Sheets.v4;

using InternalLibrary.Services;

namespace InternalLibrary.iOS.Services
{
    public class IosGoogleAPIConfiguration : IGoogleAPIConfoguration
    {
        private const string _clientId = "1080092356389-hv8gar6e31jlc6k4cmkbav03ausklt01.apps.googleusercontent.com";
        private const string _redirectUrl = "com.softeq.internallibrary:/oauth2redirect";
        private static string _scope = SheetsService.Scope.SpreadsheetsReadonly;

        public string ClientID => _clientId;
        public string RedirectUrl => _redirectUrl;
        public string Scope => _scope;
    }
}
