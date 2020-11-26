using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MHanafy.GithubClient.Models;
using MHanafy.GithubClient.Models.Github;
using Newtonsoft.Json;
using Action = MHanafy.GithubClient.Models.Github.Action;

namespace MHanafy.GithubClient
{
    public class GithubHttpClient : IGithubClient
    {
        private readonly HttpClient _client;
        private readonly IJwtTokenFactory _jwtHelper;
        private JwtToken _appToken;
        private const string Base = "https://api.github.com/";
        public GithubHttpClient(IJwtTokenFactory jwtHelper)
        {
            _client = new HttpClient();
            _jwtHelper = jwtHelper;
        }

        public async Task<App> GetApp()
        {
            return await Execute<App>(HttpMethod.Get, $"{Base}app");
        }

        public async Task<List<Installation>> GetInstallations()
        {
            return await Execute<List<Installation>>(HttpMethod.Get, $"{Base}app/installations");
        }
        public async Task<Installation> GetInstallation(long installationId)
        {
            return await Execute<Installation>(HttpMethod.Get, $"{Base}app/installations/{installationId}");
        }

        public async Task<InstallationToken> GetInstallationToken(long installationId)
        {
            var installation = await GetInstallation(installationId);
            var accessToken = await Execute<AccessToken>(HttpMethod.Post, $"{Base}app/installations/{installationId}/access_tokens");
            return new InstallationToken(installationId, installation.Account.Login, accessToken.Token, accessToken.ExpiresAt);
        }

        public async Task<List<Repository>> GetRepositories(InstallationToken token)
        {
            var result = await Execute<InstallationRepositories>(HttpMethod.Get, $"{Base}installation/repositories", token);
            return result.Repositories;
        }

        public async Task<List<CheckSuite>> GetCheckSuites(InstallationToken token, string repo, string commit)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/commits/{commit}/check-suites";
            var result = await Execute<CommitCheckSuites>(HttpMethod.Get, url, token);
            return result.CheckSuites;
        }

        public async Task<List<PullRequest>> GetPullRequests(InstallationToken token, string repo)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/pulls";
            var result = await Execute<List<PullRequest>>(HttpMethod.Get, url, token);
            return result;
        }

        public async Task<DetailedPullRequest> GetPullRequest(InstallationToken token, string repo, long pullNumber)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/pulls/{pullNumber}";
            var result = await Execute<DetailedPullRequest>(HttpMethod.Get, url, token);
            return result;
        }

        public async Task ClosePullRequest(InstallationToken token, string repo, long pullNumber)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/pulls/{pullNumber}";
            await Execute(HttpMethod.Patch, url, token, $"{{\"state\": \"{PullRequest.PullStatus.Closed}\"}}");
        }

        public async Task<List<Review>> GetReviews(InstallationToken token, string repo, long pullNumber)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/pulls/{pullNumber}/reviews";
            var result = await Execute<List<Review>>(HttpMethod.Get, url, token);
            return result;
        }

        public async Task<CheckRun> SubmitCheckRun(InstallationToken token, string repo, CheckRun checkRun)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/check-runs";
            var output = await Execute<CheckRun>(HttpMethod.Post, url, token, JsonConvert.SerializeObject(checkRun));
            return output;
        }

        public async Task UpdateCheckRun(InstallationToken token, string repo, long checkRunId, string status,
            string conclusion, CheckRunOutput output, DateTime? completeDate = null, List<Action> actions = null)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/check-runs/{checkRunId}";
            var payload = new CheckRunUpdate { Status = status, Conclusion = conclusion, Output = output, Actions = actions};
            if (completeDate != null) payload.CompletedAt = completeDate.Value.ToUniversalTime();
            await Execute<CheckRun>(HttpMethod.Patch, url, token, JsonConvert.SerializeObject(payload));
        }

        public async Task<DetailedUser> GetUser(InstallationToken token, string login)
        {
            var url = $"{Base}users/{login}";
            var result = await Execute<DetailedUser>(HttpMethod.Get, url, token);
            return result;
        }

        public async Task<List<CheckRun>> GetCheckRuns(InstallationToken token, string repo, long checkSuiteId)
        {
            var url = $"{Base}repos/{token.Account}/{repo}/check-suites/{checkSuiteId}/check-runs";
            var result = await Execute<CommitCheckRuns>(HttpMethod.Get, url, token);
            return result.CheckRuns;
        }

        private async Task<T> Execute<T>(HttpMethod method, string uri, InstallationToken token = null, string payload = null)
        {
            var response = await Execute(method, uri, token, payload);
            return JsonConvert.DeserializeObject<T>(response);
        }

        public async Task<string> Execute(HttpMethod method, string uri, InstallationToken token = null, string payload = null)
        {
            var message = await GetMessage(method, uri, token);
            if (payload != null) message.Content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Got a {response.StatusCode}, response body: '{content}'");
            }
            return content;
        }

        private async Task<HttpRequestMessage> GetMessage(HttpMethod method, string uri, InstallationToken token = null)
        {
            var message = new HttpRequestMessage(method, $"{uri}?per_page=100");
            message.Headers.Add("Accept", "application/vnd.github.machine-man-preview+json");
            message.Headers.Add("Accept", "application/vnd.github.antiope-preview+json");
            message.Headers.Add("User-Agent", "Mhanafy-GithubClient");
            if (token != null)
            {
                if (!token.IsValid)
                {
                    token = await GetInstallationToken(token.InstallationId);
                }

                message.Headers.Add("Authorization", $"token {token.Token}");
            }
            else
            {
                if (_appToken == null || !_appToken.IsValid) _appToken = _jwtHelper.GetJwtToken(1);
                message.Headers.Add("Authorization", $"Bearer {_appToken.Value}");
            }

            return message;
        }


    }
}
