using Google.Apis.Sheets.v4;

using InternalLibrary.Services;

namespace InternalLibrary.Droid
{
    public class AndroidGoogleAPIConfiguration : IGoogleAPIConfoguration
    {
        private const string _clientId = "1080092356389-pijle81n4oub12o2ob27knkild8dlcb5.apps.googleusercontent.com";
        private const string _redirectUrl = "com.softeq.internallibrary:/oauth2redirect";
        private static string _scope = SheetsService.Scope.SpreadsheetsReadonly;

        public string ClientID => _clientId;
        public string RedirectUrl => _redirectUrl;
        public string Scope => _scope;
    }
}
