using Elang.Domain.Entities;
using SharedKernel.Common;

namespace Elang.Domain.Specifications.Filters;

public record CardFilter : BaseFilter
{
    public string? Translation { get; init; }

    public string? English { get; init; }

    public string? ContextDescription { get; init; }

    public CardType? Type { get; set; }

    public long? TopicId { get; init; }
}
