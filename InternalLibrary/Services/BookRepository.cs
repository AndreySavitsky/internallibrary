using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using InternalLibrary.ViewModels;

namespace InternalLibrary.Services
{
    public class BookRepository : IBookRepository
    {
        public async Task<IEnumerable<BookViewModel>> GetBookListAsync()
        {
            return new List<BookViewModel>
            {
                new BookViewModel() { Title = "First Book" },
                new BookViewModel() { Title = "Second Book" },
                new BookViewModel() { Title = "Third Book" },
            };
        }
    }
}
