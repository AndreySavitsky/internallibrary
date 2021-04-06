using System.Threading.Tasks;
using Firebase.Auth;

namespace InternalLibrary.Forms.Servsices
{
    public interface IFirebaseAuthenticator
    {
        bool IsAdmin { get; }
        FirebaseAuth FirebaseAuth { get; }

        Task<User> SignInAsync(string email, string password);
        Task<User> SignUpAsync(string email, string password);
        Task<User> RefreshTokenAsync();
    }
}
