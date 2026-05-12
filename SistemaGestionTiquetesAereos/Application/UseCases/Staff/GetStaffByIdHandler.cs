using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed class GetStaffByIdHandler : IRequestHandler<GetStaffByIdQuery, Domain.Entities.Staff>
{
    private readonly IStaff _staffRepository;

    public GetStaffByIdHandler(IStaff staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<Domain.Entities.Staff> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
    {
        return await _staffRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Staff), request.Id);
    }
}
