using System;
using System.Linq;
using System.Threading.Tasks;
using MHanafy.GithubClient;
using MHanafy.GithubClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GithubClient.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine($"This is a sample app that shows how to use this library to interact with Github and submit checkruns using the new API");
            System.Console.WriteLine($"For this to work, ensure to download your github app key, and update the settings.json file with AppId and the location of the key file");
            System.Console.WriteLine();

            var serviceProvider = SetupDi();
            //using DI to get the client, would use settings to get the required values from the config file.
            var client = serviceProvider.GetService<IGithubClient>();

            //listing all installations that the app has access to
            var installations = await client.GetInstallations();
            if(installations.Count == 0)
            {
                var app = await client.GetApp();
                System.Console.WriteLine($"No installations found for this App, visit https://github.com/settings/apps/{app.Name}/installations to install it");
                return;
            }

            System.Console.WriteLine($"Found {installations.Count} installations:");
            foreach(var installation in installations)
            {
                System.Console.WriteLine($"Installation Id: {installation.Id} Account: {installation.Account.Login}");
            }
            System.Console.WriteLine();
            
            //Get an installation token to access the first installation; tokens are then renewed automatically before expiry
            var installationId = installations[0].Id;
            var token = await client.GetInstallationToken(installationId);

            //Get all repositories accessible to the app in this installation
            var repos = await client.GetRepositories(token);
            if(repos.Count == 0)
            {
                System.Console.WriteLine($"No repositories found for installation {installationId}, ensure that the App was granted access");
                return;
            }
            System.Console.WriteLine($"Found {repos.Count} repositories in installation {installationId}:");
            foreach(var repository in repos)
            {
                System.Console.WriteLine($"Repository Name: {repository.Name} Url: {repository.Url}");
            }
            System.Console.WriteLine();

            var repo = repos[0].Name;

            var pulls = await client.GetPullRequests(token, repo);
             if(pulls.Count == 0)
            {
                System.Console.WriteLine($"No pull requests found for repo {repo}, create one to see more :)");
                return;
            }

            System.Console.WriteLine($"Found {pulls.Count} pull requests in repo {repo}:");
            foreach(var pullRequest in pulls)
            {
                System.Console.WriteLine($"Owner: {pullRequest.User.Login} Created at: {pullRequest.CreatedAt} from branch: {pullRequest.Head.Ref} to branch: {pullRequest.Base.Ref}");
            }

            var pull = pulls[0];

            //GitHub creates a check suite automatically when code is pushed to the repository.
            //Apps then create checkruns against it, which represents a check (i.e. Test coverage, security analysis, etc ...
            var checkSuite = (await client.GetCheckSuites(token, repo, pull.Head.Sha))
                .FirstOrDefault(x => x.LatestCheckRunsCount > 0);

                if(checkSuite == null)
            {
                System.Console.WriteLine($"No checkruns for pull request {pull.Number}, Submit a checkrun by calling {nameof(client.SubmitCheckRun)}");
                return;
            }
            System.Console.WriteLine();

            var settings = serviceProvider.GetService<IOptions<GithubSettings>>();

            var checkruns = await client.GetCheckRuns(token, repo, checkSuite.Id);
            //Check to see if there's a checkrun that belongs to your app
            var run = checkruns.FirstOrDefault(x => x.App.Id == settings.Value.ApplicationId);
            if (run == null)
            {
                System.Console.WriteLine($"No checkruns for pull request {pull.Number}, Submit a checkrun by calling {nameof(client.SubmitCheckRun)}");
                return;
            }

            System.Console.WriteLine($"CheckRun Id: {run.Id} Name: {run.Name} Status: {run.Status} Conclusion: {run.Conclusion} Output: {run.Output.Title}");

            ////To issue a raw request, use Execute
            //var url = $"https://api.github.com/app/installations";
            //var payload = $"";
            //var result = await client.Execute(System.Net.Http.HttpMethod.Get, url, token, payload);


            //// ****** Uncomment below code to submit a new checkrun
            //var checkRun = new CheckRun("Some fancy checkrun name", pull.Head.Sha, CheckRun.RunStatus.InProgress)
            //{
            //    StartedAt = DateTime.UtcNow
            //};
            //await client.SubmitCheckRun(token, repo, checkRun);
        }

        private static IServiceProvider SetupDi()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();
            
            var serviceProvider = new ServiceCollection()
                .AddOptions()
                //Read AppId and location of key file from config
                .Configure<GithubSettings>(config.GetSection("GithubSettings"))
                .AddScoped<IJwtTokenFactory, GithubJwtTokenFactory>()
                .AddScoped<IGithubClient, GithubHttpClient>()
                .BuildServiceProvider();

            return serviceProvider;
        }

    }     

}
