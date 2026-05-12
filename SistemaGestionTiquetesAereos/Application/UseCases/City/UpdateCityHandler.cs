using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed class UpdateCityHandler : IRequestHandler<UpdateCityCommand>
{
    private readonly ICity _cityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCityHandler(ICity cityRepository, IUnitOfWork unitOfWork)
    {
        _cityRepository = cityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cityRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.City), request.Id);

        if (await _cityRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("City with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.RegionId, request.IsActive);

        _cityRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
