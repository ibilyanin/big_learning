using SharedKernel.Common;

namespace Elang.ApplicationCore.Cards.Dto;

public record CardFilterDto : BaseFilterDto
{
    public string? Translation { get; init; }
    public string? English { get; init; }
    public string? ContextDescription { get; init; }
    public string? Type { get; set; }
    public long? TopicId { get; init; }
}
