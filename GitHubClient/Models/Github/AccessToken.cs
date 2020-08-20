using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public interface IAccessToken
    {
        string Token { get; set; }
        DateTime ExpiresAt { get; set; }
        Permission Permissions { get; set; }
        string RepositorySelection { get; set; }
    }

    public class AccessToken : IAccessToken
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