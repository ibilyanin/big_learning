using Ardalis.Specification;
using Elang.Domain.Entities;
using Elang.Domain.Specifications.Filters;

namespace Elang.Domain.Specifications;

public class CardSearchSpecification : Specification<Card>
{
    public CardSearchSpecification(CardFilter cardFilter)
    {
        Query.Where(x => x.Type == cardFilter.Type, cardFilter.Type is not null);
        Query.Where(x => x.English.Contains(cardFilter.English!), cardFilter.English is not null);
        Query.Where(x => x.Translation!.Contains(cardFilter.Translation!), cardFilter.Translation is not null);
        Query.Where(x => x.ContextDescription!.Contains(cardFilter.ContextDescription!), cardFilter.ContextDescription is not null);
        Query.Where(x => x.Topics!.Any(xx => xx.Id == (cardFilter.TopicId ?? 0)), cardFilter.TopicId is not null);

        Query.Take(cardFilter.Take ?? 0, cardFilter.Take is not null);
        Query.Skip(cardFilter.Skip ?? 0, cardFilter.Skip is not null);

        Query.Include(x => x.Topics);
        Query.AsNoTracking();
    }
}
