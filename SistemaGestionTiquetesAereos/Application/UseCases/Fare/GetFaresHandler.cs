using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed class GetFaresHandler : IRequestHandler<GetFaresQuery, IReadOnlyList<Domain.Entities.Fare>>
{
    private readonly IFare _fareRepository;

    public GetFaresHandler(IFare fareRepository)
    {
        _fareRepository = fareRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Fare>> Handle(GetFaresQuery request, CancellationToken cancellationToken)
    {
        return _fareRepository.GetAllAsync(cancellationToken);
    }
}
