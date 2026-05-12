using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Person;

public sealed class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Guid>
{
    private readonly IPerson _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonHandler(IPerson personRepository, IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        if (await _personRepository.ExistsByDocumentNumberAsync(request.DocumentNumber, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Person with DocumentNumber '" + request.DocumentNumber + "' already exists.");
        }
        var entity = new Domain.Entities.Person(request.FirstName, request.LastName, request.DocumentTypeId, request.DocumentNumber, request.BirthDate, request.AddressId);

        await _personRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
