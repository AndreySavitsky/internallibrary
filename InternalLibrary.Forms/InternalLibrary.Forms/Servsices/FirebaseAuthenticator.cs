using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace InternalLibrary.Forms.Servsices
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        private const string WebAPIKey = "AIzaSyBR0u185PPGqqbtUEp_edvJZlFIwATjQrg";
        private const string FirebaseTokenPropertyName = "FirebaseToken";

        public async Task<User> SignInAsync(string email, string password)
        {
            User user = null;

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set(FirebaseTokenPropertyName, serializedContent);
                user = auth.User;
                await App.Current.MainPage.DisplayAlert("SignIn", "Success!", "Ok");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("SignIn", e.Message, "Ok");
            }

            return user;
        }

        public async Task<string> SignUpAsync(string email, string password)
        {
            string token = string.Empty;

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                token = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("SignUp", "Success!", "Ok");
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("SignUp", e.Message, "Ok");
            }

            return token;
        }

        public async Task<User> RefreshTokenAsync()
        {
            User user = null;

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var savedFirebaseAuth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get(FirebaseTokenPropertyName, string.Empty));
                var refreshedContent = await authProvider.RefreshAuthAsync(savedFirebaseAuth);
                user = savedFirebaseAuth.User;
                Preferences.Set(FirebaseTokenPropertyName, JsonConvert.SerializeObject(refreshedContent));
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("SignUp", e.Message, "Ok");
            }

            return user;
        }
    }
}
