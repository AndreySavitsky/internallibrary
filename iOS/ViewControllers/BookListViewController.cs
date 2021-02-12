using System;

using InternalLibrary.iOS.Views;
using InternalLibrary.Models;
using InternalLibrary.ViewModels;

using Softeq.XToolkit.Bindings.iOS.Bindable;
using Softeq.XToolkit.WhiteLabel.iOS;

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

            TableView.RegisterNibForCellReuse(BookTableViewCell.Nib, BookTableViewCell.Key);
            TableView.Source = new BindableTableViewSource<Book, BookTableViewCell>(TableView, ViewModel.ItemModels)
            {
                HeightForRow = 60,
                ItemClick = ViewModel.SelectItemCommand
            };
        }
    }
}

