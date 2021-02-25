using Android.App;
using Android.Content;
using Android.OS;

using InternalLibrary.ViewModels;

using Softeq.XToolkit.WhiteLabel.Droid;

namespace InternalLibrary.Droid.Views
{
    [Activity(Label = "Book list", MainLauncher = true, Theme = "@style/AppTheme")]
    public class BookListPageActivity : ActivityBase<BookListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var authenticator = ViewModel.GoogleAuthenticator;
            var intent = authenticator.GetUI(this);
            StartActivity(intent);

            authenticator.Completed += OnAuthenticationCompleted;
            authenticator.Error += OnAuthenticationFailed;

        }

        private void OnAuthenticationCompleted(object sender, Xamarin.Auth.AuthenticatorCompletedEventArgs e)
        {
            var intent = new Intent(this, typeof(BookListPageActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);

            if (e.IsAuthenticated)
            {

            }
            else
            {
                new AlertDialog.Builder(this)
                           .SetTitle("Authentication canceled")
                           .SetMessage("You didn't completed the authentication process")
                           .Show();
            }
        }

        private void OnAuthenticationFailed(object sender, Xamarin.Auth.AuthenticatorErrorEventArgs e)
        {
            new AlertDialog.Builder(this)
                           .SetTitle(e.Message)
                           .SetMessage(e.Exception?.ToString())
                           .Show();
        }
    }
}
