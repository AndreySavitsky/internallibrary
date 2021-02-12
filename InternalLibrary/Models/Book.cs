using System;
using Softeq.XToolkit.Common;

namespace InternalLibrary.Models
{
    public class Book : ObservableObject
    {
        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
