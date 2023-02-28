using FluentValidation;

namespace Elang.ApplicationCore.Topics.Dto.Validators;
internal class TopicFilterDtoValidator : AbstractValidator<TopicFilterDto>
{
    public TopicFilterDtoValidator()
    {
        RuleFor(x => x.Take).LessThan(500);
        RuleFor(x => x.Name).MaximumLength(100);
    }
}
