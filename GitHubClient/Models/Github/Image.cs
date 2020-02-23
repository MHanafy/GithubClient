using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Image
    {
        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }
    }
}