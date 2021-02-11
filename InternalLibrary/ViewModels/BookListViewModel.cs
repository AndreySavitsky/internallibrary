using System;

using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;

        public BookListViewModel(IPageNavigationService pageNavigationService)
        {
            _pageNavigationService = pageNavigationService;
        }

        public override void OnInitialize()
        {
            base.OnInitialize();
        }
    }
}
