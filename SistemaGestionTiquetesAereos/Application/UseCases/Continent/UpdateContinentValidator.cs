using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Continent;

public sealed class UpdateContinentValidator : AbstractValidator<UpdateContinentCommand>
{
    public UpdateContinentValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}
