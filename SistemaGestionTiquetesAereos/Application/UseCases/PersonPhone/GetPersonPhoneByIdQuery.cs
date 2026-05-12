using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed record GetPersonPhoneByIdQuery(Guid Id) : IRequest<Domain.Entities.PersonPhone>;
