using Elang.ApplicationCore.Topics.Dto;
using MediatR;
using SharedKernel.Common;

namespace Elang.ApplicationCore.Topics.Commands;

public readonly record struct CreateTopicCommand(CreateTopicDto Topic) : IRequest<ServiceResult<long>>;
public readonly record struct UpdateTopicCommand(TopicDto Topic) : IRequest<ServiceResult>;
public readonly record struct GetTopicsCommand(TopicFilterDto Filters) : IRequest<ServiceResult<TopicDto[]>>;
public readonly record struct GetTopicCommand(long Id) : IRequest<ServiceResult<TopicDto>>;
public readonly record struct DeleteTopicCommand(long Id) : IRequest<ServiceResult>;
