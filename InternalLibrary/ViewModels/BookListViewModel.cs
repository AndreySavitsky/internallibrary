using System.Threading.Tasks;

using InternalLibrary.Models;
using InternalLibrary.Services;

using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

using Xamarin.Auth;

namespace InternalLibrary.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPageNavigationService _pageNavigationService;
        private readonly IGoogleAPIConfoguration _googleAPIConfoguration;
        private readonly IGoogleAuthenticator _googleAuthenticator;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IBookRepository bookRepository,
            IGoogleAPIConfoguration googleAPIConfoguration,
            IGoogleAuthenticator googleAuthenticator)
        {
            _pageNavigationService = pageNavigationService;
            _bookRepository = bookRepository;
            _googleAPIConfoguration = googleAPIConfoguration;
            _googleAuthenticator = googleAuthenticator;

            _googleAuthenticator.Authenticator.Completed += NotifyAuthorizationCompleted;

            ItemModels = new ObservableRangeCollection<Book>();

            SelectItemCommand = new AsyncCommand<Book>(SelectItem);
        }

        private void NotifyAuthorizationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var token = new GoogleAuthenticationToken
                {
                    TokenType = e.Account.Properties["token_type"],
                    AccessToken = e.Account.Properties["access_token"]
                };

                ItemModels.AddRange(_bookRepository.GetBookListAsync(_googleAPIConfoguration, token));
            }
        }

        public ObservableRangeCollection<Book> ItemModels { get; }

        public ICommand<Book> SelectItemCommand { get; }

        public OAuth2Authenticator GoogleAuthenticator => _googleAuthenticator.Authenticator;

        private async Task SelectItem(Book model)
        {
            _pageNavigationService
                .For<WebViewModel>()
                .WithParam(x => x.Book, model)
                .Navigate();
        }
    }
}
