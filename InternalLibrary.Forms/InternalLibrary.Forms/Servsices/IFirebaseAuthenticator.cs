using System.Threading.Tasks;
using Firebase.Auth;

namespace InternalLibrary.Forms.Servsices
{
    public interface IFirebaseAuthenticator
    {
        Task<User> SignInAsync(string email, string password);
        Task<User> SignUpAsync(string email, string password);
        Task<User> RefreshTokenAsync();
    }
}
