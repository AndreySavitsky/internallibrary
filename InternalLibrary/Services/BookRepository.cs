using System.Collections.Generic;
using System.Linq;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

using InternalLibrary.Models;

namespace InternalLibrary.Services
{
    public class BookRepository : IBookRepository
    {
        private const string _spreadsheetId = "1w9GBc2LHN2UvCe7SGtcnczz5bPrW1dj5URfj6_oVhe0";
        private const string _range = "Books!A:F";
        private List<Book> books;

        public BookRepository()
        {
            books = new List<Book>();
        }

        public IEnumerable<Book> GetBookListAsync(IGoogleAPIConfoguration googleAPIConfoguration, GoogleAuthenticationToken googleAuthenticationToken)
        {
            var secrets = new ClientSecrets() { ClientId = googleAPIConfoguration.ClientID };
            var initializer = new GoogleAuthorizationCodeFlow.Initializer { ClientSecrets = secrets };
            var flow = new GoogleAuthorizationCodeFlow(initializer);
            var refreshToken = new TokenResponse { RefreshToken = googleAuthenticationToken.AccessToken };
            var credentials = new UserCredential(flow, "user", refreshToken);

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "InternalLibrary",
            });

            var request = service.Spreadsheets.Values.Get(_spreadsheetId, _range);
            var response = request.Execute().Values.Where(value => value.Count > 5);

            books.Clear();

            books.AddRange(response.Select(value => new Book()
            {
                Title = value[1].ToString(),
                InternationalStandardBookNumber = value[3].ToString(),
                Status = value[4].ToString(),
                URL = value[5].ToString()
            }));

            books.RemoveAt(0);

            return books;
        }
    }
}
