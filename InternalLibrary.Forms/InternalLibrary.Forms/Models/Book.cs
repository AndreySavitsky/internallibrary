using Softeq.XToolkit.Common;

namespace InternalLibrary.Forms.Models
{
    public class Book : ObservableObject
    {
        private string _title = string.Empty;
        private string _url = string.Empty;
        private string _status = string.Empty;
        private string _internationalStandardBookNumber = string.Empty;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string URL
        {
            get => _url;
            set => Set(ref _url, value);
        }

        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public string InternationalStandardBookNumber
        {
            get => _internationalStandardBookNumber;
            set => Set(ref _internationalStandardBookNumber, value);
        }
    }
}
