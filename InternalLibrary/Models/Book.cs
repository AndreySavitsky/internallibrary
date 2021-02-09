using System;
namespace InternalLibrary.Models
{
    public class Book
    {
        public string Name { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string InternationalStandardBookNumber { get; set; }
        public string Location { get; set; } = String.Empty;
    }
}
