using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Output
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("annotations_count")]
        public long AnnotationsCount { get; set; }

        [JsonProperty("annotations_url")]
        public Uri AnnotationsUrl { get; set; }

        [JsonProperty("annotations")]
        public Annotation[] Annotations { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }
    }
}