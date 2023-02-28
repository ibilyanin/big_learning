namespace Elang.Domain.Entities;

public record Topic
{
    public long Id { get; init; }

    public string Name { get; init; } = null!;

    public virtual IList<Card>? Cards { get; set; }

    public static implicit operator long(Topic topic) => topic.Id;
    public static explicit operator Topic(long id) => new Topic() { Id = id };
}
