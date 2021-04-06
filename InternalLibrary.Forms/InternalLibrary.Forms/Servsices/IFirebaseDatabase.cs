using System.Collections.Generic;
using System.Threading.Tasks;
using InternalLibrary.Forms.Models;

namespace InternalLibrary.Forms.Servsices
{
    public interface IFirebaseDatabase
    {
        Task<Dictionary<string, string>> GetAdminsAsync();
        Task<Dictionary<string, Book>>  GetBooksAsync();
        Task<Book> SetBookAsync(Book book);
        Task<Book> PushBookAsync(Book book);
        Task<Book> GetBookAsync(string book);
        Task<Book> UpdateBookAsync(Book book);
        void DeleteBookAsync(Book book);
    }
}
