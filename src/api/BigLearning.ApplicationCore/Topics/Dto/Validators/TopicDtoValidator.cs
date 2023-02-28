using FluentValidation;

namespace Elang.ApplicationCore.Topics.Dto.Validators;
internal class TopicDtoValidator : AbstractValidator<TopicDto>
{
    public TopicDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);
    }
}
