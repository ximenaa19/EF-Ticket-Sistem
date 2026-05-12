using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed class CreateSeatLocationTypeValidator : AbstractValidator<CreateSeatLocationTypeCommand>
{
    public CreateSeatLocationTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
