namespace Elang.ApplicationCore.Topics.Dto;

public record TopicDto
{
    public long Id { get; init; }
    public required string Name { get; init; }
}
