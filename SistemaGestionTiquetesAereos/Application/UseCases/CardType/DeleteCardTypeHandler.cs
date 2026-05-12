using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed class DeleteCardTypeHandler : IRequestHandler<DeleteCardTypeCommand>
{
    private readonly ICardType _cardTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCardTypeHandler(ICardType cardTypeRepository, IUnitOfWork unitOfWork)
    {
        _cardTypeRepository = cardTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCardTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cardTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CardType), request.Id);

        _cardTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
