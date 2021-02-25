using Android.OS;
using InternalLibrary.ViewModels;

using Softeq.XToolkit.WhiteLabel.Droid;

namespace InternalLibrary.Droid.Views
{
    [Android.App.Activity(Label = "BookListPageActivity", MainLauncher = true, Theme = "@style/AppTheme")]
    public class BookListPageActivity : ActivityBase<BookListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BookList);
        }
    }
}
