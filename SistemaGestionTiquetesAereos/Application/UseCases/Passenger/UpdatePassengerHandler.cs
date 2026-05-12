using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed class UpdatePassengerHandler : IRequestHandler<UpdatePassengerCommand>
{
    private readonly IPassenger _passengerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePassengerHandler(IPassenger passengerRepository, IUnitOfWork unitOfWork)
    {
        _passengerRepository = passengerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePassengerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _passengerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Passenger), request.Id);

        entity.Update(request.PersonId, request.PassengerTypeId, request.IsActive);

        _passengerRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
