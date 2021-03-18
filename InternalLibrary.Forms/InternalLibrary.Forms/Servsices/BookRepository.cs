using System.Collections.Generic;
using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using InternalLibrary.Forms.Models;

namespace InternalLibrary.Forms.Servsices
{
    public class BookRepository : IBookRepository
    {
        private const string _clientID = "1080092356389-bt65r6clcof1a05smp4kp6k7uut9nm4d.apps.googleusercontent.com";
        private const string _spreadsheetId = "1w9GBc2LHN2UvCe7SGtcnczz5bPrW1dj5URfj6_oVhe0";
        private const string _range = "Books!A:F";
        private List<Book> books;

        public BookRepository()
        {
            books = new List<Book>();
        }

        public IEnumerable<Book> GetBookListAsync(string token)
        {
            var secrets = new ClientSecrets() { ClientId = _clientID };
            var initializer = new GoogleAuthorizationCodeFlow.Initializer { ClientSecrets = secrets };
            var flow = new GoogleAuthorizationCodeFlow(initializer);
            var refreshToken = new TokenResponse { RefreshToken = token };
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