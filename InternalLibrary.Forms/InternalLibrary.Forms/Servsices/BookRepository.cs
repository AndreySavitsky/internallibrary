using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using InternalLibrary.Forms.Models;

namespace InternalLibrary.Forms.Servsices
{
    public class BookRepository : IBookRepository
    {
        static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };

        private const string _spreadsheetId = "1w9GBc2LHN2UvCe7SGtcnczz5bPrW1dj5URfj6_oVhe0";
        private const string _range = "Books!A:G";
        private List<Book> books;

        public BookRepository()
        {
            books = new List<Book>();
        }

        public async Task<IEnumerable<Book>> GetBookListAsync(string token)
        {
            var credential = GoogleCredential.FromAccessToken(token).CreateScoped(Scopes);

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "InternalLibrary",
            });

            var request = service.Spreadsheets.Values.Get(_spreadsheetId, _range);
            var response = request.Execute().Values.Where(value => value.Count > 6);

            books.Clear();

            books.AddRange(response.Select(value => new Book()
            {
                Title = value[1].ToString(),
                Language = value[2].ToString(),
                InternationalStandardBookNumber = value[4].ToString(),
                Description = value[5].ToString(),
                URL = value[6].ToString()
            }));

            books.RemoveAt(0);

            return books;
        }
    }
}