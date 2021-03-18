using System.Collections.Generic;
using InternalLibrary.Forms.Models;

namespace InternalLibrary.Forms.Servsices
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBookListAsync(string token);
    }
}
