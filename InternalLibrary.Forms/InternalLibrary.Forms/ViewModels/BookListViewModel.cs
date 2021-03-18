using System.Linq;
using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.Forms.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;
        private readonly IWebAuthenticatorService _webAuthenticatorService;
        private readonly IBookRepository _bookRepository;

        private string _title = string.Empty;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IWebAuthenticatorService webAuthenticatorService,
            IBookRepository bookRepository)
        {
            _pageNavigationService = pageNavigationService;
            _webAuthenticatorService = webAuthenticatorService;
            _bookRepository = bookRepository;

            Authenticate();
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

        private async void Authenticate()
        {
            var result = await _webAuthenticatorService.OnGoogleAuthenticate();
            var bookList = _bookRepository.GetBookListAsync(result.AccessToken);

            await App.Current.MainPage.DisplayAlert("Books got", bookList.Count().ToString(), "Ok");
        }
    }
}
