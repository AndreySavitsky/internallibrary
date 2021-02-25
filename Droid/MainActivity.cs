using Android.App;
using Android.Widget;
using Android.OS;
using Softeq.XToolkit.WhiteLabel.Droid;
using InternalLibrary.ViewModels;

namespace InternalLibrary.Droid
{
    [Activity(Label = "internallibrary", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/AppTheme")]
    public class MainActivity : ActivityBase<MainViewModel>
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };
        }
    }
}

