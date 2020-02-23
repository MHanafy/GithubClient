using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class CheckRun
    {
        public static class RunStatus
        {
            public const string Queued = "queued";
            public const string InProgress = "in_progress";
            public const string Completed = "completed";

        }

        public static class RunConclusion
        {
            public const string None = "None";
            public const string Success = "success";
            public const string Failure = "failure";
            public const string Neutral = "neutral";
            public const string Cancelled = "cancelled";
            public const string TimedOut = "timed_out";
            public const string ActionRequired = "action_required";
        }

        public CheckRun(string name, string sha, string status)
        {
            Name = name;
            HeadSha = sha;
            Status = status;
            Actions = new List<Action>();
        }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("head_sha")]
        public string HeadSha { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("started_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartedAt { get; set; }

        [JsonProperty("conclusion", NullValueHandling = NullValueHandling.Ignore)]
        public string Conclusion { get; set; }

        [JsonProperty("completed_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public Output Output { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Action> Actions { get; set; }
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("node_id", NullValueHandling = NullValueHandling.Ignore)]
        public string NodeId { get; set; }


        [JsonProperty("external_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("html_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("details_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri DetailsUrl { get; set; }

        [JsonProperty("check_suite", NullValueHandling = NullValueHandling.Ignore)]
        public CheckSuite CheckSuite { get; set; }

        [JsonProperty("app", NullValueHandling = NullValueHandling.Ignore)]
        public App App { get; set; }

        [JsonProperty("pull_requests", NullValueHandling = NullValueHandling.Ignore)]
        public List<PullRequest> PullRequests { get; set; }

    }
}