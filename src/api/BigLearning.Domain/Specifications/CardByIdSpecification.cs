using Ardalis.Specification;
using Elang.Domain.Entities;

namespace Elang.Domain.Specifications;

public class CardByIdSpecification : Specification<Card>, ISingleResultSpecification<Card>
{
    public CardByIdSpecification(long id)
    {
        Query.Where(x => x.Id == id);
        Query.Include(x => x.Topics);
    }
}
