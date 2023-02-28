using Elang.ApplicationCore.Cards.Dto;
using Elang.Domain.Entities;
using FluentValidation;

namespace Elang.ApplicationCore.Cards.Validators;
internal class CardFilterDtoValidator : AbstractValidator<CardFilterDto>
{
    public CardFilterDtoValidator()
    {
        RuleFor(x => x.Take).LessThan(500);
        RuleFor(x => x.Type).IsEnumName(typeof(CardType)).When(x => x.Type != null);
    }
}
