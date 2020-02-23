using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Comments
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}