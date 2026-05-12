using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed class GetStaffHandler : IRequestHandler<GetStaffQuery, IReadOnlyList<Domain.Entities.Staff>>
{
    private readonly IStaff _staffRepository;

    public GetStaffHandler(IStaff staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Staff>> Handle(GetStaffQuery request, CancellationToken cancellationToken)
    {
        return _staffRepository.GetAllAsync(cancellationToken);
    }
}
