using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Installation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account")]
        public IAccount Account { get; set; }

        [JsonProperty("repository_selection")]
        public string RepositorySelection { get; set; }

        [JsonProperty("access_tokens_url")]
        public Uri AccessTokensUrl { get; set; }

        [JsonProperty("repositories_url")]
        public Uri RepositoriesUrl { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("app_id")]
        public long AppId { get; set; }

        [JsonProperty("target_id")]
        public long TargetId { get; set; }

        [JsonProperty("target_type")]
        public string TargetType { get; set; }

        [JsonProperty("permissions")]
        public Permission Permissions { get; set; }

        [JsonProperty("events")]
        public string[] Events { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("single_file_name")]
        public object SingleFileName { get; set; }
    }
}