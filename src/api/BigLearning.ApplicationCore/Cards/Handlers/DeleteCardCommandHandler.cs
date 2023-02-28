using Ardalis.Specification;
using Elang.Domain.Entities;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Exceptions;
using SharedKernel.Services;

namespace Elang.ApplicationCore.Cards.Handlers;

public readonly record struct DeleteCardCommand(long CardId) : IRequest<ServiceResult>;

internal sealed class DeleteCardCommandHandler : BaseCommandHandler, IRequestHandler<DeleteCardCommand, ServiceResult>
{
    private readonly IRepositoryBase<Card> _cardRepository;

    public DeleteCardCommandHandler(IRepositoryBase<Card> cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<ServiceResult> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        => await DeleteCard(request.CardId, cancellationToken);

    public async Task<ServiceResult> DeleteCard(long cardId, CancellationToken ct)
    {
        var card = _cardRepository.GetByIdAsync(cardId, ct);
        if (card == null)
        {
            return Failure(new EntityNotFoundException(nameof(Card), cardId));
        }

        await _cardRepository.DeleteAsync(cardId, ct);

        return Success();
    }

}
