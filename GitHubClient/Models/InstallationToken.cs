using System;

namespace MHanafy.GithubClient.Models
{
    public interface IInstallationToken
    {
        long InstallationId { get; }
        string Account { get; }
        string Token { get; }
        DateTime Expiry { get; }
        bool IsValid { get; }
    }

    public class InstallationToken : IInstallationToken
    {
        public long InstallationId { get; }

        public string Account { get; }
        public string Token{ get; }
        public DateTime Expiry{ get; }

        public InstallationToken(long installationId, string account, string token, DateTime expiry)
        {
            InstallationId = installationId;
            Account = account;
            Token = token;
            Expiry = expiry;
        }

        public bool IsValid => (Expiry - DateTime.UtcNow).TotalSeconds >= DateHelper.SafetyMargin;
    }
}
