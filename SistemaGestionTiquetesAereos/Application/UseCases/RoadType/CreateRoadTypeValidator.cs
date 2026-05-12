using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed class CreateRoadTypeValidator : AbstractValidator<CreateRoadTypeCommand>
{
    public CreateRoadTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
