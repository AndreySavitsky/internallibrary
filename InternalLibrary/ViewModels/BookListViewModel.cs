using System.Threading.Tasks;

using InternalLibrary.Models;
using InternalLibrary.Services;

using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IPageNavigationService _pageNavigationService;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IBookRepository bookRepository)
        {
            _pageNavigationService = pageNavigationService;
            _bookRepository = bookRepository;

            ItemModels = new ObservableRangeCollection<Book>();

            SelectItemCommand = new AsyncCommand<Book>(SelectItem);
        }

        public ObservableRangeCollection<Book> ItemModels { get; }

        public ICommand<Book> SelectItemCommand { get; }

        public override async void OnInitialize()
        {
            base.OnInitialize();

            ItemModels.AddRange(await _bookRepository.GetBookListAsync());
        }

        private async Task SelectItem(Book model)
        {
            _pageNavigationService
                .For<WebViewModel>()
                .WithParam(x => x.URL, model.URL)
                .Navigate();
        }
    }
}
