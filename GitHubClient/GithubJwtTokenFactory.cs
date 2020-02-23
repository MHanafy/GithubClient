using System.IO;
using MHanafy.GithubClient.Models;
using Microsoft.Extensions.Options;

namespace MHanafy.GithubClient
{
    public class GithubJwtTokenFactory : JwtTokenFactory
    {
        public GithubJwtTokenFactory(IOptions<GithubSettings> options) 
        {
            using var stream = File.OpenRead(PathHelper.GetFullPath(options.Value.KeyPath));
            Initialize(stream, options.Value.ApplicationId.ToString());
        }
    }
}
