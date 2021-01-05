using System;
using Newtonsoft.Json;

namespace AppSight.FileHashChecker.Library.Net.GitHub.Repositories
{
    public class GitHubRepositoryRelease
    {
        public string Id { get; set; }

        public string Url { get; set; }

        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        public string Name { get; set; }

        public bool Draft { get; set; }

        public bool Prerelease { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset PublishedAt { get; set; }
    }
}