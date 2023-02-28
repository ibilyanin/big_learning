using Elang.Api.Common;
using Elang.ApplicationCore.Cards.Dto;
using Elang.ApplicationCore.Cards.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Elang.Api.Controllers;

[ApiController]
[Route("cards")]
public class CardController : ElangControllerBase
{
    private readonly IMediator _mediator;

    public CardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<CardDto[]>> Get([FromQuery] CardFilterDto cardFilterDto, CancellationToken ct = default)
    {
        var result = await _mediator.Send(new GetCardsCommand(cardFilterDto), ct);

        return OkOrFault(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CardDto>> Get(long id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetCardCommand(id), ct);

        return OkOrFault(result);
    }

    [HttpPost]
    public async Task<ActionResult<long>> Create(CreateCardCommand createCardCommand, CancellationToken ct)
    {
        var result = await _mediator.Send(createCardCommand, ct);

        return CreatedOrFault(result, nameof(Get), result);
    }

    [HttpPut]
    public async Task<ActionResult> Update(CardDto cardDto, CancellationToken ct)
    {
        var result = await _mediator.Send(new UpdateCardCommand(cardDto), ct);

        return NoContentOrFault(result);
    }

    [HttpDelete("{cardId}")]
    public async Task<ActionResult> Delete(long cardId, CancellationToken ct)
    {
        var result = await _mediator.Send(new DeleteCardCommand(cardId), ct);

        return NoContentOrFault(result);
    }
}
