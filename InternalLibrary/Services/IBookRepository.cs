using System.Collections.Generic;
using System.Threading.Tasks;

using InternalLibrary.ViewModels;

namespace InternalLibrary.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookViewModel>> GetBookListAsync();
    }
}
