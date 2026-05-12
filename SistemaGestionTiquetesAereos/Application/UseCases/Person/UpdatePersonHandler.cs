using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IPerson _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonHandler(IPerson personRepository, IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _personRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Person), request.Id);

        if (await _personRepository.ExistsByDocumentNumberAsync(request.DocumentNumber, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Person with DocumentNumber '" + request.DocumentNumber + "' already exists.");
        }
        entity.Update(request.FirstName, request.LastName, request.DocumentTypeId, request.DocumentNumber, request.BirthDate, request.AddressId, request.IsActive);

        _personRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
