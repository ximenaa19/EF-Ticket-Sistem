using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airport;

public sealed class UpdateAirportHandler : IRequestHandler<UpdateAirportCommand>
{
    private readonly IAirport _airportRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAirportHandler(IAirport airportRepository, IUnitOfWork unitOfWork)
    {
        _airportRepository = airportRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _airportRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Airport), request.Id);

        if (await _airportRepository.ExistsByIataCodeAsync(request.IataCode, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Airport with IataCode '" + request.IataCode + "' already exists.");
        }
        entity.Update(request.Name, request.IataCode, request.IcaoCode, request.CityId, request.IsActive);

        _airportRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
