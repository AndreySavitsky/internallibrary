using System.Threading.Tasks;
using System.Windows.Input;
using InternalLibrary.Forms.Enums;
using InternalLibrary.Forms.Models;
using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;

namespace InternalLibrary.Forms.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        private readonly IFirebaseDatabase _firebaseDatabase;
        private readonly IFirebaseAuthenticator _firebaseAuthenticator;

        public BookViewModel(IFirebaseDatabase firebaseDatabase,
            IFirebaseAuthenticator firebaseAuthenticator)
        {
            _firebaseDatabase = firebaseDatabase;
            _firebaseAuthenticator = firebaseAuthenticator;

            RequestBookCommand = new AsyncCommand(OnRequestBook);
        }

        public Book Book { get; set; }

        public ICommand RequestBookCommand { get; }

        private async Task OnRequestBook()
        {
            Book.Status = BookStatus.Booked;
            Book.Email = _firebaseAuthenticator.FirebaseAuth.User.Email;

            await _firebaseDatabase.UpdateBookAsync(Book);
        }
    }
}
