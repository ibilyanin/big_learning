namespace Elang.ApplicationCore.Cards.Dto;

public record CardDto
{
    public long Id { get; init; }

    public required string English { get; init; }
    public required string Type { get; init; }

    public string? Translation { get; set; }
    public string? ContextDescription { get; init; }
    public long[]? Topics { get; init; }
}
