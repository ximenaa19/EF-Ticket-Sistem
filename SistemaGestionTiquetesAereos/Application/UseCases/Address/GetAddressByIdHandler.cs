using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, Domain.Entities.Address>
{
    private readonly IAddress _addressRepository;

    public GetAddressByIdHandler(IAddress addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<Domain.Entities.Address> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        return await _addressRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Address), request.Id);
    }
}
