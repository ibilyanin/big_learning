using Ardalis.Specification;
using AutoMapper;
using Elang.ApplicationCore.Topics.Commands;
using Elang.ApplicationCore.Topics.Dto;
using Elang.Domain.Entities;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Exceptions;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Topics.Handlers;

internal class GetTopicCommandHandler : BaseCommandHandler, IRequestHandler<GetTopicCommand, ServiceResult<TopicDto>>
{
    private readonly IRepositoryBase<Topic> _topicRepository;
    private readonly IMapper _mapper;

    public GetTopicCommandHandler(IRepositoryBase<Topic> topicRepository, IMapper mapper)
    {
        _topicRepository = topicRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult<TopicDto>> Handle(GetTopicCommand request, CancellationToken cancellationToken)
        => await GetTopic(request.Id, cancellationToken).ConfigureAwait(false);

    private async Task<ServiceResult<TopicDto>> GetTopic(long topicId, CancellationToken ct)
    {
        var topic = await _topicRepository.GetByIdAsync(topicId, ct);
        if (topic == null)
        {
            return Failure<TopicDto>(new EntityNotFoundException(nameof(Topic), topicId));
        }

        return Success(_mapper.Map<TopicDto>(topic));
    }
}
