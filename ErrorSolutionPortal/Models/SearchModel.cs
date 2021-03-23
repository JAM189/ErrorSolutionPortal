using Newtonsoft.Json;

namespace ErrorSolutionPortal.Models
{
    public class SearchModel
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("length")]
        public int length { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        public string SortDir { get; set; }

        public string SortColumn { get; set; }
    }
}
