using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Country;

public sealed class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand>
{
    private readonly ICountry _countryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCountryHandler(ICountry countryRepository, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _countryRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Country), request.Id);

        _countryRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
