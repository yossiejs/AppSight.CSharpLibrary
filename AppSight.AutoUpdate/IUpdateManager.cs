using System;
using System.Threading.Tasks;

namespace AppSight.AutoUpdate
{
    public interface IUpdateManager
    {
        event EventHandler<UpdateFoundEventArgs> UpdateFound;

        Task CheckForUpdatesAsync();
    }
}