using Xamarin.Forms;

namespace InternalLibrary.Forms.Views
{
    public partial class StartView : ContentViewBase
    {
        public StartView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ActivityIndicator.IsRunning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ActivityIndicator.IsRunning = false;
        }
    }
}
