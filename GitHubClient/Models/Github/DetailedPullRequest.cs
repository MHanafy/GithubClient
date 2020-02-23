using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class DetailedPullRequest : PullRequest
    {
        [JsonProperty("merged")]
        public bool Merged { get; set; }

        [JsonProperty("mergeable")]
        public bool? Mergeable { get; set; }

        [JsonProperty("rebaseable")]
        public bool Rebaseable { get; set; }

        [JsonProperty("mergeable_state")]
        public string MergeableState { get; set; }

        [JsonProperty("merged_by")]
        public object MergedBy { get; set; }

        [JsonProperty("comments")]
        public long Comments { get; set; }

        [JsonProperty("review_comments")]
        public long ReviewComments { get; set; }

        [JsonProperty("maintainer_can_modify")]
        public bool MaintainerCanModify { get; set; }

        [JsonProperty("commits")]
        public long Commits { get; set; }

        [JsonProperty("additions")]
        public long Additions { get; set; }

        [JsonProperty("deletions")]
        public long Deletions { get; set; }

        [JsonProperty("changed_files")]
        public long ChangedFiles { get; set; }
    }
}