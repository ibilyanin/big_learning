namespace Elang.ApplicationCore.Cards.Dto;

public class CreateCardDto
{
    public required string Translation { get; init; }
    public required string English { get; init; }
    public required string Type { get; set; }

    public string? ContextDescription { get; init; }
    public long[]? Topics { get; init; }
}
