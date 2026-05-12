using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed class CreatePhoneCodeHandler : IRequestHandler<CreatePhoneCodeCommand, Guid>
{
    private readonly IPhoneCode _phoneCodeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePhoneCodeHandler(IPhoneCode phoneCodeRepository, IUnitOfWork unitOfWork)
    {
        _phoneCodeRepository = phoneCodeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePhoneCodeCommand request, CancellationToken cancellationToken)
    {
        if (await _phoneCodeRepository.ExistsByCodeAsync(request.Code, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("PhoneCode with Code '" + request.Code + "' already exists.");
        }
        var entity = new Domain.Entities.PhoneCode(request.CountryId, request.Code);

        await _phoneCodeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
