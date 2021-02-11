using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public SimpleListViewModelBase(
            IDialogsService dialogsService)
        {
            _dialogsService = dialogsService;

            ItemModels = new ObservableRangeCollection<BookViewModel>();

            SelectItemCommand = new AsyncCommand<BookViewModel>(SelectItem);
        }

        public ObservableRangeCollection<BookViewModel> ItemModels { get; }

        public ICommand<BookViewModel> SelectItemCommand { get; }

        public override void OnInitialize()
        {
            base.OnInitialize();

            ItemModels.AddRange(new List<BookViewModel>
            {
                new BookViewModel()
                {
                    Title = "First book",
                    InternationalStandardBookNumber = String.Empty,
                    DateOfIssue = DateTime.Now,
                    Location = String.Empty
                },
                new BookViewModel()
                {
                    Title = "Second book",
                    InternationalStandardBookNumber = String.Empty,
                    DateOfIssue = DateTime.Now,
                    Location = String.Empty
                },
                new BookViewModel()
                {
                    Title = "Third book",
                    InternationalStandardBookNumber = String.Empty,
                    DateOfIssue = DateTime.Now,
                    Location = String.Empty
                }
            });
        }

        private async Task SelectItem(BookViewModel viewModel)
        {
            await _dialogsService.ShowDialogAsync(new AlertDialogConfig("Selected", viewModel.Title, "OK"));
        }
    }
}
