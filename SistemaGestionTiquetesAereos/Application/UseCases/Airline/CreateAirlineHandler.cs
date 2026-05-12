using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Airline;

public sealed class CreateAirlineHandler : IRequestHandler<CreateAirlineCommand, Guid>
{
    private readonly IAirline _airlineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAirlineHandler(IAirline airlineRepository, IUnitOfWork unitOfWork)
    {
        _airlineRepository = airlineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAirlineCommand request, CancellationToken cancellationToken)
    {
        if (await _airlineRepository.ExistsByIataCodeAsync(request.IataCode, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException($"Airline with IATA code '{request.IataCode}' already exists.");
        }

        var airline = new Domain.Entities.Airline(request.Name, request.IataCode);

        await _airlineRepository.AddAsync(airline, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return airline.Id;
    }
}
