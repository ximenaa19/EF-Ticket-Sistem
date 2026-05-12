using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Season;

public sealed class UpdateSeasonValidator : AbstractValidator<UpdateSeasonCommand>
{
    public UpdateSeasonValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
