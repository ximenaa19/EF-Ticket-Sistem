using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed class GetPassengerTypesHandler : IRequestHandler<GetPassengerTypesQuery, IReadOnlyList<Domain.Entities.PassengerType>>
{
    private readonly IPassengerType _passengerTypeRepository;

    public GetPassengerTypesHandler(IPassengerType passengerTypeRepository)
    {
        _passengerTypeRepository = passengerTypeRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.PassengerType>> Handle(GetPassengerTypesQuery request, CancellationToken cancellationToken)
    {
        return _passengerTypeRepository.GetAllAsync(cancellationToken);
    }
}
