using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed class CreateFlightRoleHandler : IRequestHandler<CreateFlightRoleCommand, Guid>
{
    private readonly IFlightRole _flightRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlightRoleHandler(IFlightRole flightRoleRepository, IUnitOfWork unitOfWork)
    {
        _flightRoleRepository = flightRoleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFlightRoleCommand request, CancellationToken cancellationToken)
    {
        if (await _flightRoleRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("FlightRole with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.FlightRole(request.Name);

        await _flightRoleRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
