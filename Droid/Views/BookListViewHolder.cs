using Android.Views;
using Android.Widget;

using InternalLibrary.Models;

using Softeq.XToolkit.Bindings.Droid.Bindable;
using Softeq.XToolkit.Bindings.Extensions;

namespace InternalLibrary.Droid.Views
{
    [BindableViewHolderLayout(Resource.Layout.item_book)]
    public class BookListViewHolder : BindableViewHolder<Book>
    {
        private readonly TextView _label;
        private readonly TextView _internationalStandardBookNumber;
        private readonly TextView _status;

        public BookListViewHolder(View view) : base(view)
        {
            _label = view.FindViewById<TextView>(Resource.Id.item_book_label);
            _internationalStandardBookNumber = view.FindViewById<TextView>(Resource.Id.item_book_isbn);
            _status = view.FindViewById<TextView>(Resource.Id.item_book_status);
        }

        public override void DoAttachBindings()
        {
            base.DoAttachBindings();

            this.Bind(() => ViewModel.Title, () => _label.Text);
            this.Bind(() => ViewModel.InternationalStandardBookNumber, () => _internationalStandardBookNumber.Text);
            this.Bind(() => ViewModel.Status, () => _status.Text);
        }
    }
}
