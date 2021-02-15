﻿using Softeq.XToolkit.Common;

namespace InternalLibrary.Models
{
    public class Book : ObservableObject
    {
        private string _title = string.Empty;
        private string _url = string.Empty;

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
    }
}
