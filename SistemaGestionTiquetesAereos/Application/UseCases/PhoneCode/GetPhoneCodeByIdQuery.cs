using MediatR;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed record GetPhoneCodeByIdQuery(Guid Id) : IRequest<Domain.Entities.PhoneCode>;
