using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class CheckRunUpdate
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        [JsonProperty("conclusion", NullValueHandling = NullValueHandling.Ignore)]
        public string Conclusion { get; set; }
        [JsonProperty("completed_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CompletedAt { get; set; }
        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public CheckRunOutput Output { get; set; }

    }
}