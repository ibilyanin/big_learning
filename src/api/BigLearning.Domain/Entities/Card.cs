namespace Elang.Domain.Entities;

public record Card
{
    public long Id { get; init; }

    public string? Translation { get; init; }

    public string English { get; init; } = null!;

    public string? ContextDescription { get; init; }

    public CardType Type { get; set; }

    public virtual IList<Topic>? Topics { get; set; }

    public static implicit operator Card(long value)
       => new()
       {
           Id = value,
           English = null!
       };
}
