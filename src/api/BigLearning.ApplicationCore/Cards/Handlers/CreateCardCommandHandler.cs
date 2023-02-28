using Ardalis.Specification;
using AutoMapper;
using Elang.ApplicationCore.Cards.Dto;
using Elang.Domain.Specifications;
using Elang.Domain.Entities;
using FluentValidation;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Cards.Handlers;

public readonly record struct CreateCardCommand(CreateCardDto Card) : IRequest<ServiceResult<long>>;

internal sealed class CreateCardCommandHandler : BaseCommandHandler, IRequestHandler<CreateCardCommand, ServiceResult<long>>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IRepositoryBase<Card> _cardRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCardDto> _createCardValidator;

    public CreateCardCommandHandler(IRepositoryBase<Topic> topicRepository,
                                    IRepositoryBase<Card> cardRepository,
                                    IMapper mapper,
                                    IValidator<CreateCardDto> createCardValidator)
    {
        _topicRepository = topicRepository;
        _cardRepository = cardRepository;
        _mapper = mapper;
        _createCardValidator = createCardValidator;
    }

    public async Task<ServiceResult<long>> Handle(CreateCardCommand request, CancellationToken ct)
        => await CreateCard(request.Card, ct);

    private async Task<ServiceResult<long>> CreateCard(CreateCardDto cardDto, CancellationToken ct)
    {
        var validationResults = await _createCardValidator.ValidateAsync(cardDto, ct);
        if (!validationResults.IsValid)
        {
            return Failure<long>(new ValidationException(validationResults.Errors));
        }

        var newCard = _mapper.Map<Card>(cardDto);
        if (cardDto.Topics is not null)
        {
            newCard.Topics = await _topicRepository.ListAsync(new TopicByIdsSpecification(cardDto.Topics), ct);
        }

        var createdCard = await _cardRepository.AddAsync(newCard, ct);

        return Success(createdCard.Id);
    }
}

