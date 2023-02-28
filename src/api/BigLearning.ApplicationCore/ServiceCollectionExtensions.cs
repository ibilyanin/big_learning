using Elang.ApplicationCore.Cards.Dto;
using Elang.ApplicationCore.Cards.Validators;
using Elang.ApplicationCore.Topics.Dto;
using Elang.ApplicationCore.Topics.Dto.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Elang.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<TopicDto>, TopicDtoValidator>();
        services.AddScoped<IValidator<CreateTopicDto>, CreateTopicDtoValidator>();
        services.AddScoped<IValidator<TopicFilterDto>, TopicFilterDtoValidator>();

        services.AddScoped<IValidator<CardFilterDto>, CardFilterDtoValidator>();
        services.AddScoped<IValidator<CardDto>, CardDtoValidator>();
        services.AddScoped<IValidator<CreateCardDto>, CreateCardDtoValidator>();

        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

    }
}
