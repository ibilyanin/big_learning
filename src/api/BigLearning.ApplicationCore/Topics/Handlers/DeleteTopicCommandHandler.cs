using Ardalis.Specification;
using Elang.ApplicationCore.Topics.Commands;
using Elang.Domain.Entities;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Exceptions;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Topics.Handlers;

internal sealed class DeleteTopicCommandHandler : BaseCommandHandler, IRequestHandler<DeleteTopicCommand, ServiceResult>
{
    private readonly IRepositoryBase<Topic> _topicRepository;

    public DeleteTopicCommandHandler(IRepositoryBase<Topic> topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<ServiceResult> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        => await DeleteTopic(request.Id, cancellationToken);

    public async Task<ServiceResult> DeleteTopic(long topicId, CancellationToken ct)
    {
        var topic = await _topicRepository.GetByIdAsync(topicId, ct);
        if (topic == null)
        {
            return Failure(new EntityNotFoundException(nameof(Topic), topicId));
        }
        await _topicRepository.DeleteAsync(topic, ct);

        return Success();
    }

}
