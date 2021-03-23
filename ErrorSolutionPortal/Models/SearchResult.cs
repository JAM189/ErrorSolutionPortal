using ErrorSolutionPortal.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ErrorSolutionPortal.Models
{
    public class SearchResult
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty("data")]
        public IEnumerable<ErrorSolution> Data { get; set; }
    }
}
