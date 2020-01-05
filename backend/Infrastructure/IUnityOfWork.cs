using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUnityOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
