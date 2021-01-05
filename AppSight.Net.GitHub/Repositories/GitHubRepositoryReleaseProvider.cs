using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppSight.AutoUpdate;
using Newtonsoft.Json;

namespace AppSight.Net.GitHub.Repositories
{
    public class GitHubRepositoryReleaseProvider : IReleaseProvider
    {
        private HttpClient _httpClient { get; }
        private GitHubRepositoryReleaseProviderSetting _setting { get; }

        public GitHubRepositoryReleaseProvider(HttpClient httpClient, GitHubRepositoryReleaseProviderSetting setting)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _setting = setting ?? throw new ArgumentNullException(nameof(setting));
        }

        public async Task<IEnumerable<Release>> GetReleasesAsync(CancellationToken cancellationToken = default)
        {
            using (var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(string.Format(
                    GitHubRepositoriesApiConstants.ReleasesEndpointFormat,
                    _setting.OwnerName,
                    _setting.RepositoryName),
                    UriKind.Relative)
            })
            {
                using (var response = await _httpClient.SendAsync(
                    request,
                    cancellationToken).ConfigureAwait(false))
                {
                    var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var releases = JsonConvert.DeserializeObject<IEnumerable<GitHubRepositoryRelease>>(responseText);
                    return releases
                        .Select(release => new Release
                        {
                            Uri = release.HtmlUrl,
                            Version = release.TagName.Replace("v", ""),
                            Timestamp = release.PublishedAt,
                        });
                }
            }
        }

        public async Task<Release> GetLatestReleaseAsync(CancellationToken cancellationToken = default)
        {
            var releases = await GetReleasesAsync().ConfigureAwait(false);
            return releases.FirstOrDefault();
        }
    }
}
