using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public class Annotation
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("annotation_level")]
        public string AnnotationLevel { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("raw_details")]
        public string RawDetails { get; set; }

        [JsonProperty("start_line")]
        public long StartLine { get; set; }

        [JsonProperty("end_line")]
        public long EndLine { get; set; }
    }
}