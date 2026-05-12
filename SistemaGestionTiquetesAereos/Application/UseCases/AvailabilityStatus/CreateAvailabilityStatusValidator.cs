using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed class CreateAvailabilityStatusValidator : AbstractValidator<CreateAvailabilityStatusCommand>
{
    public CreateAvailabilityStatusValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
