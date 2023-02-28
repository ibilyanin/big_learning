using FluentValidation;

namespace Elang.ApplicationCore.Topics.Dto.Validators;
internal class CreateTopicDtoValidator : AbstractValidator<CreateTopicDto>
{
    public CreateTopicDtoValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(100);
    }
}
