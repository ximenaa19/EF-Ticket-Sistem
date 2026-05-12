using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed class CreateSeasonValidator : AbstractValidator<CreateSeasonCommand>
{
    public CreateSeasonValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
