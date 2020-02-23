using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Commit
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("tree_id")]
        public string TreeId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("committer")]
        public Author Committer { get; set; }
    }
}