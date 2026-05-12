using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed class UpdatePassengerTypeHandler : IRequestHandler<UpdatePassengerTypeCommand>
{
    private readonly IPassengerType _passengerTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePassengerTypeHandler(IPassengerType passengerTypeRepository, IUnitOfWork unitOfWork)
    {
        _passengerTypeRepository = passengerTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePassengerTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _passengerTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PassengerType), request.Id);

        if (await _passengerTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("PassengerType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _passengerTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
