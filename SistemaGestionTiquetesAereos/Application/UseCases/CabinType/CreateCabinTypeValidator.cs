using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed class CreateCabinTypeValidator : AbstractValidator<CreateCabinTypeCommand>
{
    public CreateCabinTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
