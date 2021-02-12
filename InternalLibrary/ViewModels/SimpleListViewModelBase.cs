using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InternalLibrary.Services;
using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.Common.Commands;
using Softeq.XToolkit.WhiteLabel.Dialogs;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.ViewModels
{
    public abstract class SimpleListViewModelBase : ViewModelBase
    {
        private readonly IDialogsService _dialogsService;
        private readonly IBookRepository _bookRepository;

        public SimpleListViewModelBase(
            IDialogsService dialogsService,
            IBookRepository bookRepository)
        {
            _dialogsService = dialogsService;
            _bookRepository = bookRepository;

            ItemModels = new ObservableRangeCollection<BookViewModel>();

            SelectItemCommand = new AsyncCommand<BookViewModel>(SelectItem);
        }

        public ObservableRangeCollection<BookViewModel> ItemModels { get; }

        public ICommand<BookViewModel> SelectItemCommand { get; }

        public override async void OnInitialize()
        {
            base.OnInitialize();

            ItemModels.AddRange(await _bookRepository.GetBookListAsync());
        }

        private async Task SelectItem(BookViewModel viewModel)
        {
            await _dialogsService.ShowDialogAsync(new AlertDialogConfig("Selected", viewModel.Title, "OK"));
        }
    }
}
