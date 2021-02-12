using System.Collections.Generic;
using System.Threading.Tasks;

using InternalLibrary.Models;

namespace InternalLibrary.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBookListAsync();
    }
}
