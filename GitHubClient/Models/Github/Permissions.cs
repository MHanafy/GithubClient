using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Permissions
    {
        [JsonProperty("checks")]
        public string Checks { get; set; }

        [JsonProperty("contents")]
        public string Contents { get; set; }

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("pull_requests")]
        public string PullRequests { get; set; }
    }
}