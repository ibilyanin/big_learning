namespace SharedKernel.Common;

public record BaseFilterDto
{
    public int? Take { get; init; }
    public int? Skip { get; init; }
}
