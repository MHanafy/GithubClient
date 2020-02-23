using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}