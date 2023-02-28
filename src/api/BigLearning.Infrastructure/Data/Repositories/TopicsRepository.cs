using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Elang.Domain.Entities;
using Elang.Infrastructure.Data.DataAccess;

namespace Elang.Infrastructure.Data.Repositories;

internal class TopicsRepository : RepositoryBase<Topic>, IRepositoryBase<Topic>
{
    public TopicsRepository(ElangDbContext elangDbContext) : base(elangDbContext)
    {
    }
}
