using Ardalis.Specification;
using Elang.ApplicationCore.Cards.Dto;
using Elang.Domain.Entities;
using Elang.Domain.Specifications;
using Elang.Domain.Specifications.Filters;
using FluentValidation;
namespace Elang.ApplicationCore.Cards.Validators;

internal class CardDtoValidator : AbstractValidator<CardDto>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IRepositoryBase<Card> _cardRepository;
    private long[]? _notFoundTopics;
    public CardDtoValidator(IRepositoryBase<Topic> topicRepository, IRepositoryBase<Card> cardRepository)
    {
        _topicRepository = topicRepository;
        _cardRepository = cardRepository;
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.English).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(x => x.Translation).NotNull().NotEmpty().MaximumLength(100);
        RuleFor(x => x.Type).NotNull().NotEmpty().IsEnumName(typeof(CardType));
        RuleFor(x => x.Topics)
            .MustAsync(ExistsAsync)
            .WithMessage((x) => $"Unknown topic ids: {string.Join(", ", _notFoundTopics ?? Array.Empty<long>())}");
        RuleFor(x => x)
            .MustAsync(ExistsAsync)
            .WithMessage("Such pair of translation - english already exists");
    }

    private async Task<bool> ExistsAsync(long[]? topicIds, CancellationToken ct)
    {
        if (topicIds is null || !topicIds.Any())
        {
            return true;
        }
        var foundTopics = await _topicRepository.ListAsync(new TopicByIdsSpecification(topicIds), ct);
        _notFoundTopics = topicIds.Except(foundTopics.Select(x => x.Id)).ToArray();

        return !_notFoundTopics.Any();
    }

    private async Task<bool> ExistsAsync(CardDto cardDto, CancellationToken ct)
    {
        var filter = new CardFilter
        {
            English = cardDto.English,
            Translation = cardDto.Translation
        };
        var card = await _cardRepository.FirstOrDefaultAsync(new CardSearchSpecification(filter), ct);

        return card is not null;
    }
}
