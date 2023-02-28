namespace SharedKernel.Common;
public record BaseFilter
{
    public int? Take { get; init; }
    public int? Skip { get; init; }
}
