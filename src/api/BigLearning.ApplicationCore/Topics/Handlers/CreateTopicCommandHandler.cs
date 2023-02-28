using Ardalis.Specification;
using AutoMapper;
using Elang.ApplicationCore.Topics.Commands;
using Elang.ApplicationCore.Topics.Dto;
using Elang.Domain.Entities;
using FluentValidation;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Topics.Handlers;

internal sealed class CreateTopicCommandHandler : BaseCommandHandler, IRequestHandler<CreateTopicCommand, ServiceResult<long>>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTopicDto> _createTopicValidator;

    public CreateTopicCommandHandler(IRepositoryBase<Topic> topicRepository,
                                     IMapper mapper,
                                     IValidator<CreateTopicDto> createTopicValidator)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
        _createTopicValidator = createTopicValidator;
    }

    public async Task<ServiceResult<long>> Handle(CreateTopicCommand request, CancellationToken ct)
        => await CreateTopic(request.Topic, ct);

    private async Task<ServiceResult<long>> CreateTopic(CreateTopicDto topicDto, CancellationToken ct)
    {
        var validationResults = _createTopicValidator.Validate(topicDto);
        if (!validationResults.IsValid)
        {
            var validationException = new ValidationException(validationResults.Errors);

            return Failure<long>(validationException);
        }
        var newTopic = _mapper.Map<Topic>(topicDto);
        var createdTopic = await _topicRepository.AddAsync(newTopic, ct);

        return Success(createdTopic.Id);
    }
}

