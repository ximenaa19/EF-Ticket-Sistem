using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardIssuer;

public sealed class CreateCardIssuerHandler : IRequestHandler<CreateCardIssuerCommand, Guid>
{
    private readonly ICardIssuer _cardIssuerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCardIssuerHandler(ICardIssuer cardIssuerRepository, IUnitOfWork unitOfWork)
    {
        _cardIssuerRepository = cardIssuerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCardIssuerCommand request, CancellationToken cancellationToken)
    {
        if (await _cardIssuerRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("CardIssuer with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.CardIssuer(request.Name);

        await _cardIssuerRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
