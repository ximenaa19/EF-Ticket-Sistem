using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed class GetAddressesHandler : IRequestHandler<GetAddressesQuery, IReadOnlyList<Domain.Entities.Address>>
{
    private readonly IAddress _addressRepository;

    public GetAddressesHandler(IAddress addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Address>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
    {
        return _addressRepository.GetAllAsync(cancellationToken);
    }
}
