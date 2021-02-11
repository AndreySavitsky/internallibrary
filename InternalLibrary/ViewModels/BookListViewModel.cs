using System;

using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.ViewModels
{
    public class BookListViewModel : SimpleListViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IDialogsService dialogsService)
            : base(dialogsService)
        {
            _pageNavigationService = pageNavigationService;
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
        }
    }
}
