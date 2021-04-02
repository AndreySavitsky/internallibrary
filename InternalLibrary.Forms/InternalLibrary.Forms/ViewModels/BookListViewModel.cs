using InternalLibrary.Forms.Models;
using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.Forms.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;
        private readonly IFirebaseDatabase _firebaseDatabase;

        private string _title = string.Empty;
        private Book _book;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IFirebaseDatabase firebaseDatabase)
        {
            _pageNavigationService = pageNavigationService;
            _firebaseDatabase = firebaseDatabase;

            BookList = new ObservableRangeCollection<Book>();

            LoadBooksAsync();
        }

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public Book SelectedBook
        {
            get => _book;
            set
            {
                Set(ref _book, value);
                _pageNavigationService.For<BookViewModel>()
                    .WithParam(x => x.Book, value)
                    .Navigate();
            }
        }

        public ObservableRangeCollection<Book> BookList { get; }

        private async void LoadBooksAsync()
        {
            BookList.AddRange((await _firebaseDatabase.GetBooksAsync()).Values);
        }
    }
}
