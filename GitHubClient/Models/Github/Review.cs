using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Review
    {
        public static class ReviewState
        {
            public static string Approved = "APPROVED";
            public static string ChangesRequested = "CHANGES_REQUESTED";
            public static string Comment = "COMMENTED";
            public static string Pending = "PENDING";
            public static string Dismissed = "DISMISSED";
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("pull_request_url")]
        public Uri PullRequestUrl { get; set; }

        [JsonProperty("author_association")]
        public string AuthorAssociation { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("submitted_at")]
        public DateTimeOffset SubmittedAt { get; set; }

        [JsonProperty("commit_id")]
        public string CommitId { get; set; }
    }
}