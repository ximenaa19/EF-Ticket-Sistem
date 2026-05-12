using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed class GetPassengersHandler : IRequestHandler<GetPassengersQuery, IReadOnlyList<Domain.Entities.Passenger>>
{
    private readonly IPassenger _passengerRepository;

    public GetPassengersHandler(IPassenger passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Passenger>> Handle(GetPassengersQuery request, CancellationToken cancellationToken)
    {
        return _passengerRepository.GetAllAsync(cancellationToken);
    }
}
