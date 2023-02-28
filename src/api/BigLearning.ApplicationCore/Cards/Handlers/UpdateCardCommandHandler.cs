using Ardalis.Specification;
using AutoMapper;
using Elang.ApplicationCore.Cards.Dto;
using Elang.Domain.Specifications;
using Elang.Domain.Entities;
using FluentValidation;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Exceptions;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Cards.Handlers;

public readonly record struct UpdateCardCommand(CardDto Card) : IRequest<ServiceResult>;

internal sealed class UpdateCardCommandHandler : BaseCommandHandler, IRequestHandler<UpdateCardCommand, ServiceResult>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IRepositoryBase<Card> _cardRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CardDto> _cardValidator;

    public UpdateCardCommandHandler(IRepositoryBase<Topic> topicRepository,
                             IRepositoryBase<Card> cardRepository,
                             IMapper mapper,
                             IValidator<CardDto> cardValidator)
    {
        _topicRepository = topicRepository;
        _cardRepository = cardRepository;
        _mapper = mapper;
        _cardValidator = cardValidator;
    }

    public async Task<ServiceResult> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        => await UpdateCard(request.Card, cancellationToken).ConfigureAwait(false);

    private async Task<ServiceResult> UpdateCard(CardDto cardDto, CancellationToken ct)
    {
        var validationResults = await _cardValidator.ValidateAsync(cardDto, ct);
        if (!validationResults.IsValid)
        {
            return Failure(new ValidationException(validationResults.Errors));
        }

        var card = await _cardRepository.GetByIdAsync(cardDto.Id, ct);
        if (card is null)
        {
            return Failure(new EntityNotFoundException(nameof(Card), cardDto.Id));
        }

        card.Topics?.Clear();
        if (cardDto.Topics is not null)
        {
            card.Topics = await _topicRepository.ListAsync(new TopicByIdsSpecification(cardDto.Topics), ct);
        }

        _mapper.Map(cardDto, card);

        await _cardRepository.UpdateAsync(card, ct);

        return Success();
    }
}
