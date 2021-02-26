using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.RecyclerView.Widget;
using InternalLibrary.Models;
using InternalLibrary.ViewModels;
using Softeq.XToolkit.Bindings.Droid.Bindable;
using Softeq.XToolkit.WhiteLabel.Droid;

namespace InternalLibrary.Droid.Views
{
    [Activity(Label = "Book list", MainLauncher = true, Theme = "@style/AppTheme")]
    public class BookListPageActivity : ActivityBase<BookListViewModel>
    {
        private RecyclerView? _booklist;

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
                SetContentView(Resource.Layout.booklist);

                _booklist = FindViewById<RecyclerView>(Resource.Id.booklist);

                _booklist.SetLayoutManager(new LinearLayoutManager(this));

                var adapter = new BindableRecyclerViewAdapter<Book, BookListViewHolder>(
                ViewModel.ItemModels)
                {
                    ItemClick = ViewModel.SelectItemCommand
                };

                _booklist.SetAdapter(adapter);
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
