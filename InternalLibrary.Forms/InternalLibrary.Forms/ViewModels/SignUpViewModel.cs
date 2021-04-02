﻿using System.Threading.Tasks;
using System.Windows.Input;
using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.Forms.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private string _title = string.Empty;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _confirmPassword = string.Empty;

        private readonly IPageNavigationService _pageNavigationService;
        private readonly IFirebaseAuthenticator _firebaseAuthenticator;

        public SignUpViewModel(
            IPageNavigationService pageNavigationService,
            IFirebaseAuthenticator firebaseAuthenticator)
        {
            _pageNavigationService = pageNavigationService;
            _firebaseAuthenticator = firebaseAuthenticator;

            CreateAccountCommand = new AsyncCommand(OnCreateAccount);
        }

        public ICommand CreateAccountCommand { get; }

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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => Set(ref _confirmPassword, value);
        }

        private async Task OnCreateAccount()
        {
            if(Password.Equals(ConfirmPassword))
            {
                var token = await _firebaseAuthenticator.SignUpAsync(Email, Password);

                if(token != null)
                {
                    _pageNavigationService.GoBack();
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Passwords are not equal", "Ok");
            }
        }
    }
}
