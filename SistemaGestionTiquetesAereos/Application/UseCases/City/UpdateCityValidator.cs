using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.City;

public sealed class UpdateCityValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(command => command.RegionId)
            .NotEmpty();
    }
}
