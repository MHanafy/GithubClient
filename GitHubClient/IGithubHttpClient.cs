using MHanafy.GithubClient.Models;
using MHanafy.GithubClient.Models.Github;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Action = MHanafy.GithubClient.Models.Github.Action;

namespace MHanafy.GithubClient
{
    public interface IGithubClient
    {
        Task<string> Execute(HttpMethod method, string uri, IInstallationToken token = null, string payload = null);
        Task<App> GetApp();
        Task<List<CheckRun>> GetCheckRuns(IInstallationToken token, string repo, long checkSuiteId);
        Task<List<CheckSuite>> GetCheckSuites(IInstallationToken token, string repo, string commit);
        Task<Installation> GetInstallation(long installationId);
        Task<List<Installation>> GetInstallations();
        Task<IInstallationToken> GetInstallationToken(long installationId);
        Task<DetailedPullRequest> GetPullRequest(IInstallationToken token, string repo, long pullNumber);
        Task ClosePullRequest(IInstallationToken token, string repo, long pullNumber);
        Task<List<PullRequest>> GetPullRequests(IInstallationToken token, string repo);
        Task<List<Repository>> GetRepositories(IInstallationToken token);
        Task<List<Review>> GetReviews(IInstallationToken token, string repo, long pullNumber);
        Task<DetailedUser> GetUser(IInstallationToken token, string login);
        Task<CheckRun> SubmitCheckRun(IInstallationToken token, string repo, CheckRun checkRun);

        Task UpdateCheckRun(IInstallationToken token, string repo, long checkRunId, string status, string conclusion,
            CheckRunOutput output, DateTime? completeDate = null, List<Action> actions = null);
    }
}