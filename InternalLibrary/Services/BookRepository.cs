using System;
using System.Collections.Generic;

using InternalLibrary.ViewModels;

namespace InternalLibrary.Services
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<BookViewModel> GetBookList()
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
