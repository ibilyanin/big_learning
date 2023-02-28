using SharedKernel.Common;

namespace Elang.ApplicationCore.Topics.Dto;

public record TopicFilterDto : BaseFilterDto
{
    public string? Name { get; init; }
}
