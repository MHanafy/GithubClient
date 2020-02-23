namespace MHanafy.GithubClient.Models
{
    public class GithubSettings
    {
        /// <summary>
        /// The path to the .pem key file downloaded from GitHub
        /// </summary>
        public string KeyPath { get; set; }   
        /// <summary>
        /// The AppId as shown in GitHub application
        /// </summary>
        public long ApplicationId { get; set; }

    }
}
