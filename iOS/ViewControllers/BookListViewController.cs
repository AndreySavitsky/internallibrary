using System;
using InternalLibrary.ViewModels;
using Softeq.XToolkit.WhiteLabel.iOS;
using UIKit;

namespace InternalLibrary.iOS.ViewControllers
{
    public partial class BookListViewController : ViewControllerBase<BookListViewModel>
    {
        public BookListViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

