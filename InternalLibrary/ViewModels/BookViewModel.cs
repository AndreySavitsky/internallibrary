using System;

using Softeq.XToolkit.Common;

namespace InternalLibrary.ViewModels
{
    public class BookViewModel : ObservableObject
    {
        private string _name = string.Empty;
        private DateTime _dateOfIssue = default;
        private string _internationalStandardBookNumber = string.Empty;
        private string _location = string.Empty;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public DateTime DateOfIssue
        {
            get => _dateOfIssue;
            set => Set(ref _dateOfIssue, value);
        }

        public string InternationalStandardBookNumber
        {
            get => _internationalStandardBookNumber;
            set => Set(ref _internationalStandardBookNumber, value);
        }

        public string Location
        {
            get => _location;
            set => Set(ref _location, value);
        }
    }
}
