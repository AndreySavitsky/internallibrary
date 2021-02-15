using System.Collections.Generic;

using Newtonsoft.Json;

namespace InternalLibrary.Models
{
    public class Root
    {
        public Feed Feed { get; set; }
    }

    public class Feed
    {
        public List<Entry> Entry { get; set; }
    }

    public class Entry
    {
        [JsonProperty("gsx$_cokwr")]
        public Title Title { get; set; }
        [JsonProperty("gsx$_cpzh4")]
        public DateOfIssue DateOfIssue { get; set; }
        [JsonProperty("gsx$_cre1l")]
        public InternationalStandardBookNumber InternationalStandardBookNumber { get; set; }
        [JsonProperty("gsx$_chk2m")]
        public Location Location { get; set; }
        [JsonProperty("gsx$_cn6ca")]
        public Id Id { get; set; }
        [JsonProperty("gsx$_ciyn3")]
        public Link Link { get; set; }
    }

    public class Title
    {
        [JsonProperty("$t")]
        public string Text { get; set; }
    }

    public class DateOfIssue
    {
        [JsonProperty("$t")]
        public string Text { get; set; }
    }

    public class InternationalStandardBookNumber
    {
        [JsonProperty("$t")]
        public string Text { get; set; }
    }

    public class Location
    {
        [JsonProperty("$t")]
        public string Text { get; set; }
    }

    public class Id
    {
        [JsonProperty("$t")]
        public string Text { get; set; }
    }

    public class Link
    {
        [JsonProperty("$t")]
        public string Text { get; set; }
    }
}
