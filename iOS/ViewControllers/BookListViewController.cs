using System;

using InternalLibrary.iOS.Views;
using InternalLibrary.Models;
using InternalLibrary.ViewModels;

using Softeq.XToolkit.Bindings.iOS.Bindable;
using Softeq.XToolkit.WhiteLabel.iOS;

using UIKit;

using Xamarin.Auth;

namespace InternalLibrary.iOS.ViewControllers
{
    public partial class BookListViewController : ViewControllerBase<BookListViewModel>
    {

        public BookListViewController(IntPtr handle) : base(handle)
        {
            Title = "Book list";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var authenticator = ViewModel.GoogleAuthenticator;
            var viewController = authenticator.GetUI();
            PresentViewController(viewController, true, null);

            authenticator.Completed += OnAuthenticationCompleted;
            authenticator.Error += OnAuthenticationFailed;
        }

        private void OnAuthenticationCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            DismissViewController(true, null);

            if(e.IsAuthenticated)
            {
                TableView.RegisterNibForCellReuse(BookTableViewCell.Nib, BookTableViewCell.Key);
                TableView.Source = new BindableTableViewSource<Book, BookTableViewCell>(TableView, ViewModel.ItemModels)
                {
                    HeightForRow = 90,
                    ItemClick = ViewModel.SelectItemCommand
                };
            }
            else
            {
                var alertController = new UIAlertController
                {
                    Title = "Authentication canceled",
                    Message = "You didn't completed the authentication process"
                };

                PresentViewController(alertController, true, null);
            }
        }

        private void OnAuthenticationFailed(object sender, AuthenticatorErrorEventArgs e)
        {
            DismissViewController(true, null);

            var alertController = new UIAlertController
            {
                Title = e.Message,
                Message = e.Exception?.ToString()
            };

            PresentViewController(alertController, true, null);
        }
    }
}

