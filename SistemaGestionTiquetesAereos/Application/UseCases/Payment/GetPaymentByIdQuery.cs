using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Payment;

public sealed record GetPaymentByIdQuery(Guid Id) : IRequest<Domain.Entities.Payment>;
