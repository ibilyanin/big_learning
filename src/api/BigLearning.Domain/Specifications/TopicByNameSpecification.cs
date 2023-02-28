using Ardalis.Specification;
using Elang.Domain.Entities;

namespace Elang.Domain.Specifications;

public class TopicByNameSpecification : Specification<Topic>
{
    public TopicByNameSpecification(string? topicName, int? take, int? skip)
    {
        Query.Where(x => x.Name.Contains(topicName!), topicName is not null);
        Query.Take(take ?? 0, take is not null);
        Query.Skip(skip ?? 0, skip is not null);
    }
}
