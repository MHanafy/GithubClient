using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class DetailedUser : User
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company")]
        public object Company { get; set; }

        [JsonProperty("blog")]
        public string Blog { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("email")]
        public object Email { get; set; }

        [JsonProperty("hireable")]
        public object Hireable { get; set; }

        [JsonProperty("bio")]
        public object Bio { get; set; }

        [JsonProperty("public_repos")]
        public long PublicRepos { get; set; }

        [JsonProperty("public_gists")]
        public long PublicGists { get; set; }

        [JsonProperty("followers")]
        public long Followers { get; set; }

        [JsonProperty("following")]
        public long Following { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}