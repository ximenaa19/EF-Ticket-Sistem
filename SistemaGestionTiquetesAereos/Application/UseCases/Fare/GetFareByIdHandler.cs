using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed class GetFareByIdHandler : IRequestHandler<GetFareByIdQuery, Domain.Entities.Fare>
{
    private readonly IFare _fareRepository;

    public GetFareByIdHandler(IFare fareRepository)
    {
        _fareRepository = fareRepository;
    }

    public async Task<Domain.Entities.Fare> Handle(GetFareByIdQuery request, CancellationToken cancellationToken)
    {
        return await _fareRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Fare), request.Id);
    }
}
