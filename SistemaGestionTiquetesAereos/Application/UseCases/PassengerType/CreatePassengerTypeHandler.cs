using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed class CreatePassengerTypeHandler : IRequestHandler<CreatePassengerTypeCommand, Guid>
{
    private readonly IPassengerType _passengerTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePassengerTypeHandler(IPassengerType passengerTypeRepository, IUnitOfWork unitOfWork)
    {
        _passengerTypeRepository = passengerTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePassengerTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _passengerTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("PassengerType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.PassengerType(request.Name);

        await _passengerTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
