﻿using InternalLibrary.Forms.Models;
using InternalLibrary.Forms.Servsices;
using Softeq.XToolkit.Common.Collections;
using Softeq.XToolkit.WhiteLabel.Mvvm;
using Softeq.XToolkit.WhiteLabel.Navigation;

namespace InternalLibrary.Forms.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private readonly IPageNavigationService _pageNavigationService;
        private readonly IWebAuthenticatorService _webAuthenticatorService;
        private readonly IBookRepository _bookRepository;

        private string _title = string.Empty;
        private Book _book;

        public BookListViewModel(
            IPageNavigationService pageNavigationService,
            IWebAuthenticatorService webAuthenticatorService,
            IBookRepository bookRepository)
        {
            _pageNavigationService = pageNavigationService;
            _webAuthenticatorService = webAuthenticatorService;
            _bookRepository = bookRepository;

            BookList = new ObservableRangeCollection<Book>();

            Authenticate();
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

        public override void OnInitialize()
        {
            base.OnInitialize();
        }

        private async void Authenticate()
        {
            var result = await _webAuthenticatorService.OnGoogleAuthenticate();

            BookList.AddRange(_bookRepository.GetBookListAsync(result.AccessToken));
        }
    }
}
