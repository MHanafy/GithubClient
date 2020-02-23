using System;

namespace MHanafy.GithubClient.Models
{
    public class InstallationToken
    {
        public readonly long InstallationId;
        public readonly string Account;
        public readonly string Token;
        public readonly DateTime Expiry;

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
