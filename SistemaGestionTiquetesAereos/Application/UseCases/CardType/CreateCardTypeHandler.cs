using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed class CreateCardTypeHandler : IRequestHandler<CreateCardTypeCommand, Guid>
{
    private readonly ICardType _cardTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCardTypeHandler(ICardType cardTypeRepository, IUnitOfWork unitOfWork)
    {
        _cardTypeRepository = cardTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCardTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _cardTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("CardType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.CardType(request.Name);

        await _cardTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
