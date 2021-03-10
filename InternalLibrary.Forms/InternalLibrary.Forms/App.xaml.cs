using InternalLibrary.Forms.Views;
using Softeq.XToolkit.WhiteLabel.Bootstrapper;
using Softeq.XToolkit.WhiteLabel.Bootstrapper.Abstract;
using Softeq.XToolkit.WhiteLabel.Navigation;
using Xamarin.Forms;

namespace InternalLibrary.Forms
{
    public partial class App
    {
        public App(IBootstrapper bootstrapper)
            : base(bootstrapper)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new BookListView());
        }

        protected override void OnStarted(IContainer container)
        {
            base.OnStarted(container);

            var navigationService = container.Resolve<IPageNavigationService>();
            navigationService.Initialize(Current.MainPage.Navigation);
        }
    }
}
