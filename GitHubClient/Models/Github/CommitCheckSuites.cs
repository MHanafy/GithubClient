using System.Collections.Generic;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class CommitCheckSuites
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("check_suites")]
        public List<CheckSuite> CheckSuites { get; set; }
    }
}