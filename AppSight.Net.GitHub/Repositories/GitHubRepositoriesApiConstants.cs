using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppSight.Net.GitHub.Repositories
{
    public static class GitHubRepositoriesApiConstants
    {
        public const string ClientName = "GitHubRepositoriesApi";
        public const string BaseUri = "https://api.github.com/";
        public const string ReleasesEndpointFormat = "repos/{0}/{1}/releases";
    }
}
