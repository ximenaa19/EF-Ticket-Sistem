using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed class GetPassengerByIdHandler : IRequestHandler<GetPassengerByIdQuery, Domain.Entities.Passenger>
{
    private readonly IPassenger _passengerRepository;

    public GetPassengerByIdHandler(IPassenger passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public async Task<Domain.Entities.Passenger> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _passengerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Passenger), request.Id);
    }
}
