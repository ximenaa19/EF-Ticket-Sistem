using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Region;

public sealed class CreateRegionHandler : IRequestHandler<CreateRegionCommand, Guid>
{
    private readonly IRegion _regionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegionHandler(IRegion regionRepository, IUnitOfWork unitOfWork)
    {
        _regionRepository = regionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        if (await _regionRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Region with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.Region(request.Name, request.CountryId);

        await _regionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
