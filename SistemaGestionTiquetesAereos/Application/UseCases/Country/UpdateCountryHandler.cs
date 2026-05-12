using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand>
{
    private readonly ICountry _countryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCountryHandler(ICountry countryRepository, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _countryRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Country), request.Id);

        if (await _countryRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Country with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsoCode, request.ContinentId, request.IsActive);

        _countryRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
