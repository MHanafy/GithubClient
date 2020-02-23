using Newtonsoft.Json;
using System.Collections.Generic;

namespace MHanafy.GithubClient.Models.Github
{
    public class InstallationRepositories
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("repository_selection")]
        public string RepositorySelection { get; set; }

        [JsonProperty("repositories")]
        public List<Repository> Repositories { get; set; }
    }
}