using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed class DeletePassengerHandler : IRequestHandler<DeletePassengerCommand>
{
    private readonly IPassenger _passengerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePassengerHandler(IPassenger passengerRepository, IUnitOfWork unitOfWork)
    {
        _passengerRepository = passengerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePassengerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _passengerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Passenger), request.Id);

        _passengerRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
