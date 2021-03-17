using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.Forms.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;
        private readonly IWebAuthenticatorService _webAuthenticatorService;

        private string _title = string.Empty;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IWebAuthenticatorService webAuthenticatorService)
        {
            _pageNavigationService = pageNavigationService;
            _webAuthenticatorService = webAuthenticatorService;
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
        }
    }
}
