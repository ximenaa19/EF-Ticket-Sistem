using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed class CreatePersonPhoneHandler : IRequestHandler<CreatePersonPhoneCommand, Guid>
{
    private readonly IPersonPhone _personPhoneRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonPhoneHandler(IPersonPhone personPhoneRepository, IUnitOfWork unitOfWork)
    {
        _personPhoneRepository = personPhoneRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePersonPhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.PersonPhone(request.PersonId, request.PhoneCodeId, request.Number, request.IsPrimary);

        await _personPhoneRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
