using System.Collections.Generic;
using System.Threading.Tasks;
using InternalLibrary.Forms.Models;

namespace InternalLibrary.Forms.Servsices
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBookListAsync(string token);
    }
}
