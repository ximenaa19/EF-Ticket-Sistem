using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed class CreateCountryHandler : IRequestHandler<CreateCountryCommand, Guid>
{
    private readonly ICountry _countryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCountryHandler(ICountry countryRepository, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        if (await _countryRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Country with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.Country(request.Name, request.IsoCode, request.ContinentId);

        await _countryRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
