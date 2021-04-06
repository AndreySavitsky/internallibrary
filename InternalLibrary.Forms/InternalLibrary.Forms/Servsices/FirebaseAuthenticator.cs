using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace InternalLibrary.Forms.Servsices
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        private const string WebAPIKey = "AIzaSyAXZ9HF8h_ZyWDG76SzDcI6aamo4rgbT_E";
        private const string FirebaseTokenPropertyName = "FirebaseToken";
        private bool _isAdmin;

        private readonly IFirebaseDatabase _firebaseDatabase;

        public FirebaseAuthenticator(IFirebaseDatabase firebaseDatabase)
        {
            _firebaseDatabase = firebaseDatabase;
        }

        public bool IsAdmin => _isAdmin;

        public FirebaseAuth FirebaseAuth => JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get(FirebaseTokenPropertyName, string.Empty));

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

                var admins = await _firebaseDatabase.GetAdminsAsync();
                _isAdmin = admins.ContainsValue(user.LocalId);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("SignIn", e.Message, "Ok");
            }

            return user;
        }

        public async Task<User> SignUpAsync(string email, string password)
        {
            User user = null;

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                user = auth.User;
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("SignUp", e.Message, "Ok");
            }

            return user;
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

                var admins = await _firebaseDatabase.GetAdminsAsync();
                _isAdmin = admins.ContainsValue(user.LocalId);
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("SignUp", e.Message, "Ok");
            }

            return user;
        }
    }
}
