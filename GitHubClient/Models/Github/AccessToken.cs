using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class AccessToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("permissions")]
        public Permission Permissions { get; set; }

        [JsonProperty("repository_selection")]
        public string RepositorySelection { get; set; }
    }
}