using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed class UpdatePersonPhoneHandler : IRequestHandler<UpdatePersonPhoneCommand>
{
    private readonly IPersonPhone _personPhoneRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonPhoneHandler(IPersonPhone personPhoneRepository, IUnitOfWork unitOfWork)
    {
        _personPhoneRepository = personPhoneRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePersonPhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await _personPhoneRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PersonPhone), request.Id);

        entity.Update(request.PersonId, request.PhoneCodeId, request.Number, request.IsPrimary, request.IsActive);

        _personPhoneRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
