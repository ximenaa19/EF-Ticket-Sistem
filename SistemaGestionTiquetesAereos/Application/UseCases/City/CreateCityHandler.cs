using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed class CreateCityHandler : IRequestHandler<CreateCityCommand, Guid>
{
    private readonly ICity _cityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCityHandler(ICity cityRepository, IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        if (await _cityRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("City with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.City(request.Name, request.RegionId);

        await _cityRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
