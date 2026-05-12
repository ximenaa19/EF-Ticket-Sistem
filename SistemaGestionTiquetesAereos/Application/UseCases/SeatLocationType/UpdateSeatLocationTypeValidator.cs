using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.SeatLocationType;

public sealed class UpdateSeatLocationTypeValidator : AbstractValidator<UpdateSeatLocationTypeCommand>
{
    public UpdateSeatLocationTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
