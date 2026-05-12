using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Domain.Entities.User>
{
    private readonly IUser _userRepository;

    public GetUserByIdHandler(IUser userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Domain.Entities.User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.User), request.Id);
    }
}
