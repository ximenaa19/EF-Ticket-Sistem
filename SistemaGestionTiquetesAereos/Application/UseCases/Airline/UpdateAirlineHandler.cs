using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed class UpdateAirlineHandler : IRequestHandler<UpdateAirlineCommand>
{
    private readonly IAirline _airlineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAirlineHandler(IAirline airlineRepository, IUnitOfWork unitOfWork)
    {
        _airlineRepository = airlineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAirlineCommand request, CancellationToken cancellationToken)
    {
        var airline = await _airlineRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Airline), request.Id);

        if (await _airlineRepository.ExistsByIataCodeAsync(request.IataCode, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException($"Airline with IATA code '{request.IataCode}' already exists.");
        }

        airline.Update(request.Name, request.IataCode, request.IsActive);

        _airlineRepository.Update(airline);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
