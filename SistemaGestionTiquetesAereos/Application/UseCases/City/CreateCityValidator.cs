using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed class CreateCityValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(command => command.RegionId)
            .NotEmpty();
    }
}
