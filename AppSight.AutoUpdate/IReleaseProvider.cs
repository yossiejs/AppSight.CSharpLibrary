using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppSight.AutoUpdate
{
    public interface IReleaseProvider
    {
        Task<IEnumerable<Release>> GetReleasesAsync(CancellationToken cancellationToken = default);
        Task<Release> GetLatestReleaseAsync(CancellationToken cancellationToken = default);
    }
}