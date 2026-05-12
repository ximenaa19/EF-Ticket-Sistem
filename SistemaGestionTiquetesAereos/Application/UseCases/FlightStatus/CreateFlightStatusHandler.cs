using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed class CreateFlightStatusHandler : IRequestHandler<CreateFlightStatusCommand, Guid>
{
    private readonly IFlightStatus _flightStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlightStatusHandler(IFlightStatus flightStatusRepository, IUnitOfWork unitOfWork)
    {
        _flightStatusRepository = flightStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFlightStatusCommand request, CancellationToken cancellationToken)
    {
        if (await _flightStatusRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("FlightStatus with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.FlightStatus(request.Name);

        await _flightStatusRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
