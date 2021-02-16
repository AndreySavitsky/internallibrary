using System;

using Foundation;

using InternalLibrary.Models;

using Softeq.XToolkit.Bindings.Extensions;
using Softeq.XToolkit.Bindings.iOS.Bindable;

using UIKit;


namespace InternalLibrary.iOS.Views
{
    public partial class BookTableViewCell : BindableTableViewCell<Book>
    {
        public static readonly NSString Key = new NSString("BookTableViewCell");
        public static readonly UINib Nib;

        static BookTableViewCell()
        {
            Nib = UINib.FromName("BookTableViewCell", NSBundle.MainBundle);
        }

        protected BookTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void DoAttachBindings()
        {
            base.DoAttachBindings();

            this.Bind(() => ViewModel.Title, () => Title.Text);
            this.Bind(() => ViewModel.Status, () => Status.Text);
            this.Bind(() => ViewModel.InternationalStandardBookNumber, () => ISBN.Text);

            if (ViewModel.Status != null)
            {
                Status.TextColor = new UIColor(255, 0, 0, 255);
            }
        }
    }
}
