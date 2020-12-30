using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class BlogDataAccess : IBlogDataAccess
    {
        private ExampleContext ExampleContext { get; }
        
        public BlogDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<BlogEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Blogs
                .Include(x => x.Category)
                .OrderBy(x => x.TimeStamp)
                .ToListAsync(ct);
        }
    }
}