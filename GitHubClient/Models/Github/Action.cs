using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Action
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}