using Ardalis.Specification;
using AutoMapper;
using Elang.ApplicationCore.Cards.Dto;
using Elang.Domain.Specifications;
using Elang.Domain.Entities;
using Elang.Domain.Specifications.Filters;
using FluentValidation;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Cards.Handlers;

public readonly record struct GetCardsCommand(CardFilterDto Filters) : IRequest<ServiceResult<CardDto[]>>;

internal class GetCardsCommandHandler : BaseCommandHandler, IRequestHandler<GetCardsCommand, ServiceResult<CardDto[]>>
{
    private readonly IRepositoryBase<Card> _cardRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CardFilterDto> _cardFilterValidator;

    public GetCardsCommandHandler(IRepositoryBase<Card> cardRepository,
                          IMapper mapper,
                          IValidator<CardFilterDto> cardFilterValidator)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
        _cardFilterValidator = cardFilterValidator;
    }

    public async Task<ServiceResult<CardDto[]>> Handle(GetCardsCommand request, CancellationToken cancellationToken)
        => await GetCards(request.Filters, cancellationToken).ConfigureAwait(false);

    public async Task<ServiceResult<CardDto[]>> GetCards(CardFilterDto cardFilterDto, CancellationToken ct)
    {
        var validationResults = _cardFilterValidator.Validate(cardFilterDto);
        if (!validationResults.IsValid)
        {
            return Failure<CardDto[]>(new FluentValidation.ValidationException(validationResults.Errors));
        }
        var cardFilter = _mapper.Map<CardFilter>(cardFilterDto);
        var cards = await _cardRepository.ListAsync(new CardSearchSpecification(cardFilter), ct);
        var cardsDto = _mapper.Map<CardDto[]>(cards);

        return Success(cardsDto);
    }
}

