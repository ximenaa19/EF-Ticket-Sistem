using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed class UpdateCabinTypeValidator : AbstractValidator<UpdateCabinTypeCommand>
{
    public UpdateCabinTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
