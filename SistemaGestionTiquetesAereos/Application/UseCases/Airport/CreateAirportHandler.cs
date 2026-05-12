using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed class CreateAirportHandler : IRequestHandler<CreateAirportCommand, Guid>
{
    private readonly IAirport _airportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAirportHandler(IAirport airportRepository, IUnitOfWork unitOfWork)
    {
        _airportRepository = airportRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        if (await _airportRepository.ExistsByIataCodeAsync(request.IataCode, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Airport with IataCode '" + request.IataCode + "' already exists.");
        }
        var entity = new Domain.Entities.Airport(request.Name, request.IataCode, request.IcaoCode, request.CityId);

        await _airportRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
