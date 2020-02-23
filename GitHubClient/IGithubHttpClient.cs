using MHanafy.GithubClient.Models;
using MHanafy.GithubClient.Models.Github;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MHanafy.GithubClient
{
    public interface IGithubClient
    {
        Task<string> Execute(HttpMethod method, string uri, InstallationToken token = null, string payload = null);
        Task<App> GetApp();
        Task<List<CheckRun>> GetCheckRuns(InstallationToken token, string repo, long checkSuiteId);
        Task<List<CheckSuite>> GetCheckSuites(InstallationToken token, string repo, string commit);
        Task<Installation> GetInstallation(long installationId);
        Task<List<Installation>> GetInstallations();
        Task<InstallationToken> GetInstallationToken(long installationId);
        Task<DetailedPullRequest> GetPullRequest(InstallationToken token, string repo, long pullNumber);
        Task<List<PullRequest>> GetPullRequests(InstallationToken token, string repo);
        Task<List<Repository>> GetRepositories(InstallationToken token);
        Task<List<Review>> GetReviews(InstallationToken token, string repo, long pullNumber);
        Task<DetailedUser> GetUser(InstallationToken token, string login);
        Task<CheckRun> SubmitCheckRun(InstallationToken token, string repo, CheckRun checkRun);
        Task UpdateCheckRun(InstallationToken token, string repo, long checkRunId, string status, string conclusion, CheckRunOutput output, DateTime? completeDate = null);
    }
}