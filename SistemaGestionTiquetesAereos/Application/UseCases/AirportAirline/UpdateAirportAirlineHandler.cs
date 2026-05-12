using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed class UpdateAirportAirlineHandler : IRequestHandler<UpdateAirportAirlineCommand>
{
    private readonly IAirportAirline _airportAirlineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAirportAirlineHandler(IAirportAirline airportAirlineRepository, IUnitOfWork unitOfWork)
    {
        _airportAirlineRepository = airportAirlineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAirportAirlineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _airportAirlineRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AirportAirline), request.Id);

        entity.Update(request.AirportId, request.AirlineId, request.IsActive);

        _airportAirlineRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
