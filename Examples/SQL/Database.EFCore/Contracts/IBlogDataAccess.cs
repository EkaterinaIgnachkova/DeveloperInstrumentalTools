using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Entities;

namespace Database.EFCore.Contracts
{
    public interface IBlogDataAccess
    {
        Task<IEnumerable<BlogEntity>> GetAllAsync(CancellationToken ct = default);
    }
}