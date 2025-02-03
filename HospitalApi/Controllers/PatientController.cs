using Application.ApiCommandHandlers.Patients.Handlers.Add;
using Application.ApiCommandHandlers.Patients.Handlers.Delete;
using Application.ApiCommandHandlers.Patients.Handlers.Update;
using Application.ApiCommandHandlers.Patients.Queries.GetAll;
using Application.ApiCommandHandlers.Patients.Queries.GetById;
using Application.ApiCommandHandlers.Patients.Queries.GetData;
using Domain.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions;
using System.Net.Mime;

namespace HospitalApi.Controllers;

[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/patients")]
public class PatientController : Controller
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "Add patient")]
    [ProducesResponseType(typeof(List<AddPatientResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Add(AddPatientCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut(Name = "Update patient")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Update(UpdatePatientCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete(Name = "Delete patient")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Update(DeletePatientCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }


    [HttpPost("search", Name = "Search")]
    [ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> SearchMeetings([FromBody] GetPatientsQuery request) => Ok(await _mediator.Send(request));

    [HttpGet("{id:long}", Name = "Patient by name id")]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetById(string id) => Ok(await _mediator.Send(new GetPatientByIdQuery(id)));

    [HttpGet("search/date-range", Name = "Search by date")]
    [ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetByDateRange(DateTime? start, DateTime? end) => Ok(await _mediator.Send(new GetByDateQuery { DateStart = start, DateEnd = end }));

    [HttpGet("search", Name = "Search in range")]
    [ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Get(
        [FromQuery(Name = "date-birth:above")] string? above,
        [FromQuery(Name = "date-birth:below")] string? below,
        [FromQuery(Name = "date-birth")] List<string> dates)
        => Ok(await _mediator.Send(new GetByDateQuery { InDates = dates, DateStart = above.ToDate(), DateEnd = below.ToDate() }));

    /* [HttpGet("search/date-birth:above={date}", Name = "Search above")]
     [ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
     public async Task<ActionResult> GetAbove(string date)
         => Ok(await _mediator.Send(new GetByDateQuery { DateStart = date.ToDate() }));

     [HttpGet("search/date-birth:below={date}", Name = "Search below")]
     [ProducesResponseType(typeof(List<PatientDto>), StatusCodes.Status200OK)]
     public async Task<ActionResult> GetBelow([FromQuery(Name = "date-birth:below")] string date)
         => Ok(await _mediator.Send(new GetByDateQuery { DateEnd = date.ToDate() }));*/
}
