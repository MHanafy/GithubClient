using System;
using Newtonsoft.Json;

namespace MHanafy.GithubClient.Models.Github
{
    public interface IAccount
    {
        string Login { get; set; }
        long Id { get; set; }
        string NodeId { get; set; }
        Uri AvatarUrl { get; set; }
        string GravatarId { get; set; }
        Uri Url { get; set; }
        Uri HtmlUrl { get; set; }
        Uri FollowersUrl { get; set; }
        string FollowingUrl { get; set; }
        string GistsUrl { get; set; }
        string StarredUrl { get; set; }
        Uri SubscriptionsUrl { get; set; }
        Uri OrganizationsUrl { get; set; }
        Uri ReposUrl { get; set; }
        string EventsUrl { get; set; }
        Uri ReceivedEventsUrl { get; set; }
        string Type { get; set; }
        bool SiteAdmin { get; set; }
    }

    public class Account : IAccount
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("followers_url")]
        public Uri FollowersUrl { get; set; }

        [JsonProperty("following_url")]
        public string FollowingUrl { get; set; }

        [JsonProperty("gists_url")]
        public string GistsUrl { get; set; }

        [JsonProperty("starred_url")]
        public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url")]
        public Uri SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url")]
        public Uri OrganizationsUrl { get; set; }

        [JsonProperty("repos_url")]
        public Uri ReposUrl { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("received_events_url")]
        public Uri ReceivedEventsUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("site_admin")]
        public bool SiteAdmin { get; set; }
    }
}