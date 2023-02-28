using Ardalis.Specification;
using Elang.Domain.Entities;

namespace Elang.Domain.Specifications;

public class TopicByIdsSpecification : Specification<Topic>
{
    public TopicByIdsSpecification(long[] ids)
    {
        Query.Where(x => ids.Contains(x.Id));
    }
}
