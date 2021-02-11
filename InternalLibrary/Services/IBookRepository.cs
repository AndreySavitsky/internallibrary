using System.Collections.Generic;

using InternalLibrary.ViewModels;

namespace InternalLibrary.Services
{
    public interface IBookRepository
    {
        IEnumerable<BookViewModel> GetBookList();
    }
}
