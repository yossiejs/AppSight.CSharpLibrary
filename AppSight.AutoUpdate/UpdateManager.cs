using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSight.AutoUpdate
{
    public class UpdateManager : IUpdateManager
    {
        public event EventHandler<UpdateFoundEventArgs> UpdateFound;
        private IReleaseProvider _releaseProvider { get; }
        private string _currentVersion { get; }

        public UpdateManager(IReleaseProvider releaseProvider, string currentVersion)
        {
            _releaseProvider = releaseProvider ?? throw new ArgumentNullException(nameof(releaseProvider));
            _currentVersion = currentVersion ?? throw new ArgumentNullException(nameof(currentVersion));
        }

        public async Task CheckForUpdatesAsync()
        {
            var latestRelease = await _releaseProvider.GetLatestReleaseAsync().ConfigureAwait(false);

            if (latestRelease == null)
            {
                return;
            }

            if (latestRelease.Version != _currentVersion)
            {
                OnUpdateFound(latestRelease.Version, latestRelease.Uri);
            }
        }

        private void OnUpdateFound(string version, string uri)
        {
            UpdateFound?.Invoke(this, new UpdateFoundEventArgs
            {
                Version = version,
                Uri = uri,
            });
        }
    }
}
