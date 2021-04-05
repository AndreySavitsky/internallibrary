using InternalLibrary.Forms.Enums;
using Softeq.XToolkit.Common;

namespace InternalLibrary.Forms.Models
{
    public class Book : ObservableObject
    {
        private string _title = string.Empty;
        private string _internationalStandardBookNumber = string.Empty;
        private string _language = string.Empty;
        private string _url = string.Empty;
        private string _email = string.Empty;
        private string _description = string.Empty;
        private string _status = BookStatus.Free;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
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

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
    }
}
