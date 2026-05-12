using AirlineTicketSystem.Api.Dtos.Countries;
using AirlineTicketSystem.Application.UseCases.Country;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CountriesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CountriesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CountryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CountryDto>>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _sender.Send(new GetCountriesQuery(), cancellationToken);

        return Ok(_mapper.Map<IReadOnlyList<CountryDto>>(entities));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CountryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _sender.Send(new GetCountryByIdQuery(id), cancellationToken);

        return Ok(_mapper.Map<CountryDto>(entity));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CountryDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Create(CreateCountryRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateCountryCommand(request.Name, request.IsoCode, request.ContinentId), cancellationToken);
        var entity = await _sender.Send(new GetCountryByIdQuery(id), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<CountryDto>(entity));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateCountryRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new UpdateCountryCommand(id, request.Name, request.IsoCode, request.ContinentId, request.IsActive), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteCountryCommand(id), cancellationToken);

        return NoContent();
    }
}
