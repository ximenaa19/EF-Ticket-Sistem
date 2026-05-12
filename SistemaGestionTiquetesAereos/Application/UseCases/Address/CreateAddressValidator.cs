using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Address;

public sealed class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressValidator()
    {
        RuleFor(command => command.RoadTypeId)
            .NotEmpty();

        RuleFor(command => command.CityId)
            .NotEmpty();

        RuleFor(command => command.Street)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(command => command.Number)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(command => command.AdditionalInfo)
            .MaximumLength(250);
    }
}
