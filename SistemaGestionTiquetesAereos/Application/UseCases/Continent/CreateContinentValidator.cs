using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed class CreateContinentValidator : AbstractValidator<CreateContinentCommand>
{
    public CreateContinentValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}
