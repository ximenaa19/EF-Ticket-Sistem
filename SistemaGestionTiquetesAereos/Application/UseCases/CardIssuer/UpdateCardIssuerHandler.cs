using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed class UpdateCardIssuerHandler : IRequestHandler<UpdateCardIssuerCommand>
{
    private readonly ICardIssuer _cardIssuerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCardIssuerHandler(ICardIssuer cardIssuerRepository, IUnitOfWork unitOfWork)
    {
        _cardIssuerRepository = cardIssuerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCardIssuerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cardIssuerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CardIssuer), request.Id);

        if (await _cardIssuerRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("CardIssuer with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _cardIssuerRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
