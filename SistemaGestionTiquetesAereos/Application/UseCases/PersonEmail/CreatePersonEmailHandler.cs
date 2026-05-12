using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonEmail;

public sealed class CreatePersonEmailHandler : IRequestHandler<CreatePersonEmailCommand, Guid>
{
    private readonly IPersonEmail _personEmailRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonEmailHandler(IPersonEmail personEmailRepository, IUnitOfWork unitOfWork)
    {
        _personEmailRepository = personEmailRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePersonEmailCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.PersonEmail(request.PersonId, request.EmailDomainId, request.LocalPart, request.IsPrimary);

        await _personEmailRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
