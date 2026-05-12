using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed class CreatePassengerHandler : IRequestHandler<CreatePassengerCommand, Guid>
{
    private readonly IPassenger _passengerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePassengerHandler(IPassenger passengerRepository, IUnitOfWork unitOfWork)
    {
        _passengerRepository = passengerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Passenger(request.PersonId, request.PassengerTypeId);

        await _passengerRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
