using System.Threading.Tasks;
using Xamarin.Essentials;

namespace InternalLibrary.Forms.Servsices
{
    public interface IWebAuthenticatorService
    {
        Task<WebAuthenticatorResult> OnGoogleAuthenticate();
    }
}
