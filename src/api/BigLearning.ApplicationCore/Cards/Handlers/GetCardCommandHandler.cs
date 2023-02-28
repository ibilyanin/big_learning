using Ardalis.Specification;
using AutoMapper;
using Elang.ApplicationCore.Cards.Dto;
using Elang.Domain.Specifications;
using Elang.Domain.Entities;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Exceptions;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Cards.Handlers;

public readonly record struct GetCardCommand(long CardId) : IRequest<ServiceResult<CardDto>>;

internal class GetCardCommandHandler : BaseCommandHandler, IRequestHandler<GetCardCommand, ServiceResult<CardDto>>
{
    private readonly IRepositoryBase<Card> _cardRepository;
    private readonly IMapper _mapper;

    public GetCardCommandHandler(IRepositoryBase<Card> cardRepository, IMapper mapper)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult<CardDto>> Handle(GetCardCommand request, CancellationToken cancellationToken)
        => await GetCard(request.CardId, cancellationToken).ConfigureAwait(false);

    private async Task<ServiceResult<CardDto>> GetCard(long cardId, CancellationToken ct)
    {
        var card = await _cardRepository.SingleOrDefaultAsync(new CardByIdSpecification(cardId), ct);
        if (card == null)
        {
            return Failure<CardDto>(new EntityNotFoundException(nameof(CardDto), cardId));
        }

        var cardDto = _mapper.Map<CardDto>(card);

        return Success(cardDto);
    }
}
