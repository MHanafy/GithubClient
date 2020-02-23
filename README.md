# GithubClient
A .Net GitHub client that allows easy access to Github API, making developing Github apps a breaze.

To get started, you'll need to create a new Github App, this can be either private or public
To create a new app, visit https://github.com/settings/apps

To use this library, you'll need:
1. A private key, grab one by heading to your app's page, and selecting `Generate a private key` and download the key to your local machine
2. The AppId, which you can get from the settings page

Now, start using the library as follows:
```C#
var serviceProvider = SetupDi();
//using DI to get the client, would use settings to get the required values from the config file.
var client = serviceProvider.GetService<IGithubClient>();

//listing all installations that the app has access to
var installations = await client.GetInstallations();

//Get an installation token to access the first installation; tokens are then renewed automatically before expiry
var token = await client.GetInstallationToken(installationId);

//Start interacting with the installation using the installation token
var checkSuites = await client.GetCheckSuites(token, repo, pull.Head.Sha)
```

This library provides models for various Github objects, but you can also issue raw requests if some models are missing
```C#
var url = $"https://api.github.com/app/installations";
var payload = $"";
var result = await client.Execute(System.Net.Http.HttpMethod.Get, url, token, payload);
```

For detailed example, update the sample app `settings.json` file with the App ID and the location of the private key file, and run it to see how easy it's to utilize github's new API from .Net.