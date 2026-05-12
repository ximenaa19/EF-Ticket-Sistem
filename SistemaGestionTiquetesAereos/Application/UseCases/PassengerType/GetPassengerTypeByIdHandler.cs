using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed class GetPassengerTypeByIdHandler : IRequestHandler<GetPassengerTypeByIdQuery, Domain.Entities.PassengerType>
{
    private readonly IPassengerType _passengerTypeRepository;

    public GetPassengerTypeByIdHandler(IPassengerType passengerTypeRepository)
    {
        _passengerTypeRepository = passengerTypeRepository;
    }

    public async Task<Domain.Entities.PassengerType> Handle(GetPassengerTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _passengerTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PassengerType), request.Id);
    }
}
