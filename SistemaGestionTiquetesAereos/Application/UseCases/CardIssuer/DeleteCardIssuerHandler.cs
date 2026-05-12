using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed class DeleteCardIssuerHandler : IRequestHandler<DeleteCardIssuerCommand>
{
    private readonly ICardIssuer _cardIssuerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCardIssuerHandler(ICardIssuer cardIssuerRepository, IUnitOfWork unitOfWork)
    {
        _cardIssuerRepository = cardIssuerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCardIssuerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cardIssuerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CardIssuer), request.Id);

        _cardIssuerRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
