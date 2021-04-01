using Softeq.XToolkit.Common;

namespace InternalLibrary.Forms.Models
{
    public class Book : ObservableObject
    {
        private string _title = string.Empty;
        private string _author = string.Empty;
        private string _internationalStandardBookNumber = string.Empty;
        private string _language = string.Empty;
        private string _url = string.Empty;
        private string _location = string.Empty;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string Author
        {
            get => _author;
            set => Set(ref _author, value);
        }

        public string InternationalStandardBookNumber
        {
            get => _internationalStandardBookNumber;
            set => Set(ref _internationalStandardBookNumber, value);
        }

        public string Language
        {
            get => _language;
            set => Set(ref _language, value);
        }

        public string URL
        {
            get => _url;
            set => Set(ref _url, value);
        }

        public string Location
        {
            get => _location;
            set => Set(ref _location, value);
        }
    }
}
