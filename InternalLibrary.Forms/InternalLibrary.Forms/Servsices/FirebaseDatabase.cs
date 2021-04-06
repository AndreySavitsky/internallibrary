using System.Collections.Generic;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using InternalLibrary.Forms.Models;

namespace InternalLibrary.Forms.Servsices
{
    public class FirebaseDatabase : IFirebaseDatabase
    {
        private const string _adminRepository = "Admins";
        private const string _bookRepository = "Books";
        private readonly FirebaseClient _client;

        public FirebaseDatabase()
        {
            _client = new FirebaseClient(new FirebaseConfig()
            {
                BasePath = "https://internallibrary-1613129931597-default-rtdb.firebaseio.com/",
                AuthSecret = "WIJm2DS25C044quptjYZ9PgbevssjFa7KltaAjxb"
            });
        }

        public async Task<Dictionary<string, string>> GetAdminsAsync()
        {
            var response = await _client.GetAsync(_adminRepository);
            var admins = response.ResultAs<Dictionary<string, string>>();

            return admins;
        }

        public async Task<Dictionary<string, Book>> GetBooksAsync()
        {
            var response = await _client.GetAsync(_bookRepository);
            var books = response.ResultAs<Dictionary<string, Book>>();

            return books;
        }

        public async Task<Book> SetBookAsync(Book book)
        {
            var response = await _client.SetAsync(_bookRepository + "/" + book.Title, book);
            return response.ResultAs<Book>();
        }

        public async Task<Book> PushBookAsync(Book book)
        {
            var response = await _client.PushAsync(_bookRepository + "/" + book.Title, book);
            return response.ResultAs<Book>();
        }

        public async Task<Book> GetBookAsync(string book)
        {
            var response = await _client.GetAsync(_bookRepository + "/" + book);
            return response.ResultAs<Book>();
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var response = await _client.UpdateAsync(_bookRepository + "/" + book.Title, book);
            return response.ResultAs<Book>();
        }

        public async void DeleteBookAsync(Book book)
        {
            await _client.DeleteAsync(_bookRepository + "/" + book.Title);
        }
    }
}
