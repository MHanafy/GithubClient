using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class CheckSuite
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("head_branch")]
        public string HeadBranch { get; set; }

        [JsonProperty("head_sha")]
        public string HeadSha { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("conclusion")]
        public object Conclusion { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("pull_requests")]
        public List<PullRequest> PullRequests { get; set; }

        [JsonProperty("app")]
        public App App { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("latest_check_runs_count")]
        public long LatestCheckRunsCount { get; set; }

        [JsonProperty("check_runs_url")]
        public Uri CheckRunsUrl { get; set; }

        [JsonProperty("head_commit")]
        public Commit HeadCommit { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }
    }
}