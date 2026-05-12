using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed class DeletePhoneCodeHandler : IRequestHandler<DeletePhoneCodeCommand>
{
    private readonly IPhoneCode _phoneCodeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePhoneCodeHandler(IPhoneCode phoneCodeRepository, IUnitOfWork unitOfWork)
    {
        _phoneCodeRepository = phoneCodeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePhoneCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _phoneCodeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.PhoneCode), request.Id);

        _phoneCodeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
