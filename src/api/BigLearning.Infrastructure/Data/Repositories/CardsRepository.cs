using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Elang.Domain.Entities;
using Elang.Infrastructure.Data.DataAccess;

namespace Elang.Infrastructure.Data.Repositories;

internal class CardsRepository : RepositoryBase<Card>, IRepositoryBase<Card>
{
    public CardsRepository(ElangDbContext dbContext) : base(dbContext)
    {
    }
}
