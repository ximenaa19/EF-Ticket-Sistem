using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CardType;

public sealed class UpdateCardTypeHandler : IRequestHandler<UpdateCardTypeCommand>
{
    private readonly ICardType _cardTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCardTypeHandler(ICardType cardTypeRepository, IUnitOfWork unitOfWork)
    {
        _cardTypeRepository = cardTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCardTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cardTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CardType), request.Id);

        if (await _cardTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("CardType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _cardTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
