using System.Collections.Generic;
using System.Threading.Tasks;

using InternalLibrary.Models;
using InternalLibrary.ViewModels;

namespace InternalLibrary.Services
{
    public class BookRepository : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetBookListAsync()
        {
            return new List<Book>
            {
                new Book() { Title = "First Book" },
                new Book() { Title = "Second Book" },
                new Book() { Title = "Third Book" },
            };
        }
    }
}
