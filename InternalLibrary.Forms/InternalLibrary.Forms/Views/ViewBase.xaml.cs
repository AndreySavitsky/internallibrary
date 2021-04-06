using Softeq.XToolkit.WhiteLabel.Mvvm;
using Xamarin.Forms;

namespace InternalLibrary.Forms.Views
{
    public partial class ContentViewBase : ContentPage
    {
        public ContentViewBase()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as ViewModelBase).OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            (BindingContext as ViewModelBase).OnDisappearing();
        }
    }
}
