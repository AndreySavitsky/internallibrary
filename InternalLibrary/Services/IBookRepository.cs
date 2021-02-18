using System.Collections.Generic;

using InternalLibrary.Models;

namespace InternalLibrary.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBookListAsync(IGoogleAPIConfoguration googleAPIConfoguration, GoogleAuthenticationToken googleAuthenticationToken);
    }
}
