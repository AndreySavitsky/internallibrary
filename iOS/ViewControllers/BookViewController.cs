using System;

using InternalLibrary.ViewModels;

using Softeq.XToolkit.WhiteLabel.iOS;

namespace InternalLibrary.iOS.ViewControllers
{
    public partial class BookViewController : ViewControllerBase<BookViewModel>
    {
        public BookViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}

