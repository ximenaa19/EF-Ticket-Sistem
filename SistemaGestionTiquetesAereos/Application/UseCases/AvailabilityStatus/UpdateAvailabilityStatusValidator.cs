using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AvailabilityStatus;

public sealed class UpdateAvailabilityStatusValidator : AbstractValidator<UpdateAvailabilityStatusCommand>
{
    public UpdateAvailabilityStatusValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
