using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using InternalLibrary.Models;

using Newtonsoft.Json;

namespace InternalLibrary.Services
{
    public class BookRepository : IBookRepository
    {
        private const string url = "https://spreadsheets.google.com/feeds/list/1w9GBc2LHN2UvCe7SGtcnczz5bPrW1dj5URfj6_oVhe0/1/public/values?alt=json";
        private HttpClient client;
        private List<Book> books;

        public BookRepository()
        {
            client = new HttpClient();
            books = new List<Book>();
        }

        public async Task<IEnumerable<Book>> GetBookListAsync()
        {
            HttpResponseMessage response = await client.GetAsync(string.Format(url));
            string result = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(result);

            books.Clear();
            books.AddRange(root.Feed.Entry.Select(x => new Book() { Title = x.Title.Text }));

            return books;
        }
    }
}
