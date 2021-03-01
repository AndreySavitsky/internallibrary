using System.Threading.Tasks;

using Android.App;
using Android.OS;

using AndroidX.AppCompat.App;

using InternalLibrary.ViewModels;

using Softeq.XToolkit.WhiteLabel;

namespace InternalLibrary.Droid.Views
{
    [Activity(
        Theme = "@style/AppTheme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            await Task.Delay(1000);

            Dependencies.PageNavigationService
                .For<BookListViewModel>()
                .Navigate();

            Finish();
        }
    }
}

