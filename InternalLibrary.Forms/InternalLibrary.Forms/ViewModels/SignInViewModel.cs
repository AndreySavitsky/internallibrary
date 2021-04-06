using System.Threading.Tasks;
using System.Windows.Input;
using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.Forms.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private string _title = string.Empty;
        private string _email = string.Empty;
        private string _password = string.Empty;

        private readonly IPageNavigationService _pageNavigationService;
        private readonly IFirebaseAuthenticator _firebaseAuthenticator;

        public SignInViewModel(
            IPageNavigationService pageNavigationService,
            IFirebaseAuthenticator firebaseAuthenticator)
        {
            _pageNavigationService = pageNavigationService;
            _firebaseAuthenticator = firebaseAuthenticator;

            SignInCommand = new AsyncCommand(OnSignIn);
            SignUpCommand = new AsyncCommand(OnSignUp);
        }

        public ICommand SignInCommand { get; }

        public ICommand SignUpCommand { get; }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();

            if(_firebaseAuthenticator.FirebaseAuth != null)
            {
                await _firebaseAuthenticator.RefreshTokenAsync();
                _pageNavigationService.NavigateToViewModel<BookListViewModel>(true, null);
            }
        }

        private async Task OnSignIn()
        {
            var user = await _firebaseAuthenticator.SignInAsync(Email, Password);

            if(user != null)
            {
                _pageNavigationService.NavigateToViewModel<BookListViewModel>(true, null);
            }
        }

        private async Task OnSignUp()
        {
            _pageNavigationService.For<SignUpViewModel>().Navigate();
        }
    }
}
