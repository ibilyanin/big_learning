namespace Elang.ApplicationCore.Topics.Dto;

public record CreateTopicDto
{
    public required string Name { get; init; }
}
