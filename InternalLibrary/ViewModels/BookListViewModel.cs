using System;
using InternalLibrary.Services;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.ViewModels
{
    public class BookListViewModel : SimpleListViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IDialogsService dialogsService,
            IBookRepository bookRepository)
            : base(dialogsService, bookRepository)
        {
            _pageNavigationService = pageNavigationService;
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
        }
    }
}
