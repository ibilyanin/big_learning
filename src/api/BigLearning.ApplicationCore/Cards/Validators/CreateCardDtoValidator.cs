using Ardalis.Specification;
using Elang.ApplicationCore.Cards.Dto;
using Elang.Domain.Specifications;
using Elang.Domain.Specifications.Filters;
using Elang.Domain.Entities;
using FluentValidation;

namespace Elang.ApplicationCore.Cards.Validators;

internal class CreateCardDtoValidator : AbstractValidator<CreateCardDto>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IRepositoryBase<Card> _cardRepository;
    private long[]? _notFoundTopics;

    public CreateCardDtoValidator(IRepositoryBase<Topic> topicRepository, IRepositoryBase<Card> cardRepository)
    {
        _topicRepository = topicRepository;
        _cardRepository = cardRepository;

        RuleFor(x => x.English).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(x => x.Translation).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(x => x.Type).NotNull().NotEmpty().IsEnumName(typeof(CardType));
        RuleFor(x => x.Topics)
            .MustAsync(TopicsExists)
            .When(x => x.Topics != null && x.Topics.Any())
            .WithMessage((x) => $"Unknown topic ids: {string.Join(", ", _notFoundTopics ?? Array.Empty<long>())}");
        RuleFor(x => x)
            .MustAsync(CardNotExists)
            .WithMessage("Such pair of translation - english already exists");
    }

    private async Task<bool> TopicsExists(long[]? topicIds, CancellationToken ct)
    {
        if (topicIds is null || !topicIds.Any())
        {
            return true;
        }
        var foundTopics = await _topicRepository.ListAsync(new TopicByIdsSpecification(topicIds), ct);
        _notFoundTopics = topicIds.Except(foundTopics.Select(x => x.Id)).ToArray();

        return !_notFoundTopics.Any();
    }

    private async Task<bool> CardNotExists(CreateCardDto cardDto, CancellationToken ct)
    {
        var filter = new CardFilter
        {
            English = cardDto.English,
            Translation = cardDto.Translation
        };
        var card = await _cardRepository.FirstOrDefaultAsync(new CardSearchSpecification(filter), ct);

        return card is null;
    }
}
