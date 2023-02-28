using System.ComponentModel.DataAnnotations;
using Elang.Api.Common;
using Elang.ApplicationCore.Topics.Commands;
using Elang.ApplicationCore.Topics.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elang.Api.Controllers;

[ApiController]
[Route("topics")]
public class TopicController : ElangControllerBase
{
    private readonly IMediator _mediator;

    public TopicController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<TopicDto[]>> GetTopics([FromQuery] TopicFilterDto topicFilterDto, CancellationToken ct = default)
    {
        var result = await _mediator.Send(new GetTopicsCommand(topicFilterDto), ct);

        return OkOrFault(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TopicDto>> GetTopic(long id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetTopicCommand(id), ct);

        return OkOrFault(result);
    }

    [HttpPost]
    public async Task<ActionResult<long>> Create(CreateTopicDto topicDto, CancellationToken ct)
    {
        var result = await _mediator.Send(new CreateTopicCommand(topicDto), ct);

        return CreatedOrFault(result, nameof(GetTopic), result);
    }

    [HttpPut]
    public async Task<ActionResult> Update(TopicDto topicDto, CancellationToken ct)
    {
        var result = await _mediator.Send(new UpdateTopicCommand(topicDto), ct);

        return NoContentOrFault(result);
    }

    [HttpDelete("{topicId}")]
    public async Task<ActionResult> Delete(long topicId, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteTopicCommand(topicId), ct);

        return NoContentOrFault(result);
    }
}
