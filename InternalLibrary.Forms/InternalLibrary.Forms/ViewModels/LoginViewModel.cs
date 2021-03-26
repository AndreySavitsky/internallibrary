﻿using System.Threading.Tasks;
using System.Windows.Input;
using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace InternalLibrary.Forms.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _title = string.Empty;
        private string _email = string.Empty;
        private string _password = string.Empty;

        private readonly IFirebaseAuthenticator _firebaseAuthenticator;

        public LoginViewModel(IFirebaseAuthenticator firebaseAuthenticator)
        {
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

        private async Task OnSignIn()
        {
            var token = await _firebaseAuthenticator.SignInAsync(Email, Password);
        }

        private async Task OnSignUp()
        {
            var token = await _firebaseAuthenticator.SignUpAsync(Email, Password);
        }
    }
}
