using System.Collections.Generic;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using InternalLibrary.Forms.Models;

namespace InternalLibrary.Forms.Servsices
{
    public class FirebaseDatabase : IFirebaseDatabase
    {
        private readonly FirebaseClient _client;

        public FirebaseDatabase()
        {
            _client = new FirebaseClient(new FirebaseConfig()
            {
                BasePath = "https://internallibrary-1613129931597-default-rtdb.firebaseio.com/",
                AuthSecret = "WIJm2DS25C044quptjYZ9PgbevssjFa7KltaAjxb"
            });
        }

        public async Task<Dictionary<string, Book>> GetBooksAsync()
        {
            FirebaseResponse response = await _client.GetAsync("Books");
            var books = response.ResultAs<Dictionary<string, Book>>();

            return books;
        }

        public async Task<Book> SetBookAsync(Book book)
        {
            SetResponse response = await _client.SetAsync("Books/" + book.Title, book);
            return response.ResultAs<Book>();
        }

        public async Task<Book> PushBookAsync(Book book)
        {
            PushResponse response = await _client.PushAsync("Books/" + book.Title, book);
            return response.ResultAs<Book>();
        }

        public async Task<Book> GetBookAsync(string book)
        {
            FirebaseResponse response = await _client.GetAsync("Books/" + book);
            return response.ResultAs<Book>();
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            FirebaseResponse response = await _client.UpdateAsync("Books/" + book.Title, book);
            return response.ResultAs<Book>();
        }

        public async void DeleteBookAsync(Book book)
        {
            await _client.DeleteAsync("Books/" + book.Title);
        }
    }
}
