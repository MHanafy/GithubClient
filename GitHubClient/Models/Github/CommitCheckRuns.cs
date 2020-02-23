using System.Collections.Generic;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class CommitCheckRuns
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("check_runs")]
        public List<CheckRun> CheckRuns { get; set; }
    }
}