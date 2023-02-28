using Ardalis.Specification;
using AutoMapper;
using Elang.Domain.Specifications;
using Elang.ApplicationCore.Topics.Commands;
using Elang.ApplicationCore.Topics.Dto;
using Elang.Domain.Entities;
using FluentValidation;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Topics.Handlers;

internal class GetTopicsCommandHandler : BaseCommandHandler, IRequestHandler<GetTopicsCommand, ServiceResult<TopicDto[]>>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<TopicFilterDto> _topicFilterValidator;

    public GetTopicsCommandHandler(IRepositoryBase<Topic> topicRepository,
                                   IMapper mapper,
                                   IValidator<TopicFilterDto> topicFilterValidator)
    {
        _mapper = mapper;
        _topicRepository = topicRepository;
        _topicFilterValidator = topicFilterValidator;
    }

    public async Task<ServiceResult<TopicDto[]>> Handle(GetTopicsCommand request, CancellationToken cancellationToken)
        => await GetTopics(request.Filters, cancellationToken).ConfigureAwait(false);

    public async Task<ServiceResult<TopicDto[]>> GetTopics(TopicFilterDto topicFilter, CancellationToken ct)
    {
        var validationResults = _topicFilterValidator.Validate(topicFilter);
        if (!validationResults.IsValid)
        {
            var validationException = new ValidationException(validationResults.Errors);

            return Failure<TopicDto[]>(validationException);
        }
        var topics = await _topicRepository.ListAsync(new TopicByNameSpecification(topicFilter.Name, topicFilter.Take, topicFilter.Skip), ct);
        var topicsDto = _mapper.Map<TopicDto[]>(topics);

        return Success(topicsDto);
    }
}

