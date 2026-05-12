using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AirportAirline;

public sealed class CreateAirportAirlineHandler : IRequestHandler<CreateAirportAirlineCommand, Guid>
{
    private readonly IAirportAirline _airportAirlineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAirportAirlineHandler(IAirportAirline airportAirlineRepository, IUnitOfWork unitOfWork)
    {
        _airportAirlineRepository = airportAirlineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAirportAirlineCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.AirportAirline(request.AirportId, request.AirlineId);

        await _airportAirlineRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
