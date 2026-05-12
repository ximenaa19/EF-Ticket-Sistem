using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed class UpdateRoadTypeValidator : AbstractValidator<UpdateRoadTypeCommand>
{
    public UpdateRoadTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}
