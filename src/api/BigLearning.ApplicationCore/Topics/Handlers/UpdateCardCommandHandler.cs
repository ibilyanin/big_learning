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

internal sealed class UpdateTopicCommandHandler : BaseCommandHandler, IRequestHandler<UpdateTopicCommand, ServiceResult>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<TopicDto> _topicValidator;

    public UpdateTopicCommandHandler(IRepositoryBase<Topic> topicRepository,
                             IMapper mapper,
                             IValidator<TopicDto> topicValidator)
    {
        _mapper = mapper;
        _topicRepository = topicRepository;
        _topicValidator = topicValidator;
    }

    public async Task<ServiceResult> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        => await UpdateTopic(request.Topic, cancellationToken).ConfigureAwait(false);

    private async Task<ServiceResult> UpdateTopic(TopicDto topicDto, CancellationToken ct)
    {
        var validationResults = _topicValidator.Validate(topicDto);
        if (!validationResults.IsValid)
        {
            var validationException = new ValidationException(validationResults.Errors);

            return Failure(validationException);
        }

        await _topicRepository.UpdateAsync(_mapper.Map<Topic>(topicDto), ct);

        return Success();
    }
}
